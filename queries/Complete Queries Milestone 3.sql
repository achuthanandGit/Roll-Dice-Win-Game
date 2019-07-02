DROP DATABASE IF EXISTS rolldiceandwin;
CREATE DATABASE rolldiceandwin;
USE rolldiceandwin;


DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `DropTables`()
BEGIN
	DROP TABLE IF EXISTS tblUserMovement;
    DROP TABLE IF EXISTS tblMysteryWheel;
    DROP TABLE IF EXISTS tblObstacleDetail;
    DROP TABLE IF EXISTS tblDiceRoll;
    DROP TABLE IF EXISTS tblGamePlayer;
    DROP TABLE IF EXISTS tblGameDetail;
    DROP TABLE IF EXISTS tblAccount;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateGameTables`()
BEGIN

-- 1. Create table for USER ACCOUNT - tblAccount
CREATE TABLE IF NOT EXISTS tblAccount(
	username VARCHAR(50) NOT NULL PRIMARY KEY,
    userPassword VARCHAR(50) NOT NULL,
    emailId VARCHAR(100) NOT NULL UNIQUE CHECK (emailId LIKE '%__@__%'),
    highScore INTEGER(20) DEFAULT 0,
    gamesPlayed INTEGER(10) DEFAULT 0,
    gamesWon INTEGER(10) DEFAULT 0,
    isAdmin ENUM('yes', 'no') DEFAULT 'no',
    lastLogin DATETIME NOT NULL DEFAULT(SYSDATE()),
    sessionCount INTEGER(10) DEFAULT 0,
    loginAttemptCount INTEGER(10) DEFAULT 0,
    accountStatus ENUM('offline', 'online', 'playing', 'locked') DEFAULT 'offline'
); 


-- 2. Creat table for each GAME - tblGameDetail
CREATE TABLE IF NOT EXISTS tblGameDetail(
	gameId INTEGER(10) NOT NULL PRIMARY KEY,
    gameHost VARCHAR(50),
    playerCount INTEGER(10) DEFAULT 1,
    winner VARCHAR(50),
    gameHighScore INTEGER(10) DEFAULT 0,
    gameStatus ENUM('waitingToStart', 'running', 'finished', 'terminated') DEFAULT 'waitingToStart',
	foreign key(gameHost) references tblAccount(username) ON DELETE SET NULL
);

-- 3. Create table for player to store game related data - tblGamePlayer
CREATE TABLE IF NOT EXISTS tblGamePlayer(
	userTokenId VARCHAR(100) NOT NULL PRIMARY KEY,
    username VARCHAR(50),
    gameId INTEGER(10) NOT NULL,
    playDate DATETIME NOT NULL DEFAULT(SYSDATE()),
    userTurn ENUM('enable', 'disable', 'playerQuit') NOT NULL,
    score INTEGER(10) DEFAULT 0,
    FOREIGN KEY(username) references tblAccount(username) ON DELETE SET NULL, 
    FOREIGN KEY(gameId) references tblGameDetail(gameId) ON DELETE CASCADE
);

-- 4. Create table for OBSTACLE DETAILS - tblObstacleDetail
CREATE TABLE IF NOT EXISTS tblObstacleDetail(
	obstaclePosition INTEGER(10) NOT NULL,
    gameId INTEGER(10) NOT NULL,
    obstaclePurpose VARCHAR(50),
    PRIMARY KEY (obstaclePosition, gameId),
    FOREIGN KEY(gameId) references tblGameDetail(gameId) ON DELETE CASCADE
); 

-- 5. Create table for the generation of MYSTERY WHEEL RESULT - tblMysteryWheel
CREATE TABLE IF NOT EXISTS tblMysteryWheel(
	wheelId INTEGER(10) NOT NULL AUTO_INCREMENT,
	gameId INTEGER(10) NOT NULL,
    obstaclePosition INTEGER(10) NOT NULL,
    wheelResult VARCHAR(50) NOT NULL,
    PRIMARY KEY (wheelId, gameId),
    FOREIGN KEY(gameId) references tblObstacleDetail(gameId) ON DELETE CASCADE,
    FOREIGN KEY(obstaclePosition) references tblObstacleDetail(obstaclePosition) ON DELETE CASCADE
);

-- 6. Create table for ROLLING THE DICE - tblDiceRoll
CREATE TABLE IF NOT EXISTS tblDiceRoll(
	diceId INTEGER(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    gameId INTEGER(10) NOT NULL,
	rollResult INTEGER(10) NOT NULL CHECK (rollResult >0 AND rollResult <7),
	FOREIGN KEY(gameId) references tblGameDetail(gameId) ON DELETE CASCADE
);

-- 7. Create table for tracking the PLAYER MOVEMENTS - tblUserMovement
DROP TABLE IF EXISTS tblUserMovement;
CREATE TABLE IF NOT EXISTS tblUserMovement(
	userTokenId VARCHAR(100) NOT NULL PRIMARY KEY,
    gameId INTEGER(10) NOT NULL,
    obstaclePosition INTEGER(10) DEFAULT 0 NOT NULL,
    userPosition INTEGER(10) DEFAULT 0 CHECK (userPosition >=0 AND userPosition <= 24),
    tokenColor VARCHAR(10) NOT NULL,
    FOREIGN KEY(userTokenId) references tblGamePlayer(userTokenId) ON DELETE CASCADE,
    FOREIGN KEY(gameId) references tblObstacleDetail(gameId) ON DELETE CASCADE,
    FOREIGN KEY(obstaclePosition) references tblObstacleDetail(obstaclePosition) ON DELETE CASCADE
);
INSERT INTO tblAccount (username,userPassword,emailId,highScore,gamesPlayed,gamesWon,isAdmin,lastLogin,sessionCount,loginAttemptCount,accountStatus) 
			VALUES ("admin","admin","admin@gmail.com",0,0,0,"yes","2019-05-21 10:43:27",0,0,"offline");
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `RegisterNewUser`(pMode VARCHAR(10), pName VARCHAR(50), pPassword VARCHAR(50), pEmail VARCHAR(100))
BEGIN
	DECLARE existedUserCount INT;
    DECLARE existedEmailCount INT;
    DECLARE accountStatus VARCHAR(10);
    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
    START TRANSACTION;
		SELECT COUNT(username) FROM tblAccount WHERE username = pName INTO existedUserCount;
		IF existedUserCount = 1 THEN
			SELECT 'username already taken' AS MESSAGE;
		ELSE 
			IF pEmail LIKE '%__@__%' THEN
				SELECT COUNT(username) FROM tblAccount WHERE emailId = pEmail INTO existedEmailCount;
				IF existedEmailCount = 1 THEN
					SELECT 'email should be unique' AS MESSAGE;
				ELSE
					INSERT INTO tblAccount (username,userPassword,emailId) VALUES (pName, pPassword, pEmail);
					IF pMode = 'admin' THEN
						SELECT 'user added succefully' AS MESSAGE;
					ELSE 
						SELECT 'registered successfuly' AS MESSAGE;
					END IF;
					 UPDATE tblAccount SET
					 sessionCount = CASE WHEN pMode = 'user' THEN sessionCount + 1
										 WHEN pMode = 'admin' THEN sessionCount
									END,
					 accountStatus = CASE WHEN pMode = 'user' THEN 'online'
										  WHEN pMode = 'admin' THEN 'offline'
									 END
					 WHERE username = pName;
				END IF;
			ELSE 
				SELECT 'invalid email' AS MESSAGE;
			END IF;
		END IF;
    COMMIT;
END //
DELIMITER;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `CheckUserExistance`(pName VARCHAR(50))
BEGIN
	DECLARE userCount INT;
    DECLARE status VARCHAR(10);
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
    SELECT COUNT(username), accountStatus FROM tblAccount WHERE username = pName INTO userCount, status;
    IF userCount = 1 THEN
		IF 'locked' = status THEN
			SELECT 'contact admin to unlock' as MESSAGE;
        ELSE
			SELECT 'user exists' AS MESSAGE;
		END IF;
	ELSE	
		SELECT 'register' AS MESSAGE;
	END IF;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `CheckUserAuthentication`(pName VARCHAR(50), pPassword VARCHAR(50))
BEGIN
    DECLARE isAdminOrNot VARCHAR(5);
    DECLARE lcPwdOkCount INT;
    DECLARE loginTries INT;
    DECLARE activeUserCount INT;
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
        
    START TRANSACTION;
		SELECT count(username) FROM tblAccount WHERE username = pName AND userPassword = pPassword INTO lcPwdOkCount;
		IF lcPwdOkCount = 1 THEN
			SELECT count(username) FROM tblAccount WHERE username = pName AND accountStatus != 'locked' INTO activeUserCount;
			IF activeUserCount = 1 THEN
				SELECT  isAdmin FROM tblAccount WHERE username = pName INTO isAdminOrNot;
				UPDATE tblAccount SET lastLogin=SYSDATE(), sessionCount = sessionCount + 1, accountStatus = 'online', loginAttemptCount = 0 WHERE username = pName;
				IF isAdminOrNot = 'yes' THEN
					SELECT 'admin login success' AS MESSAGE;
				ELSE 
					SELECT 'user login success' AS MESSAGE;
				END IF;
			ELSE
				SELECT 'contact admin to unlock' AS MESSAGE;
			END IF;
		ELSE 
			UPDATE tblAccount SET loginAttemptCount = loginAttemptCount + 1 WHERE username = pName;
			SELECT loginAttemptCount FROM tblAccount WHERE username = pName INTO loginTries;        
			IF loginTries = 5 THEN
				UPDATE tblAccount SET accountStatus = 'locked' WHERE username = pName;
				SELECT 'locked' AS MESSAGE;
			ELSE
				SELECT 'login again' AS MESSAGE;
			END IF;
		END IF;
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateNewGame`(pName VARCHAR(50))
BEGIN
	DECLARE generatedGameId INTEGER;
    DECLARE userToken VARCHAR(100);
    DECLARE tokenColor VARCHAR(10);
    DECLARE userTurn VARCHAR(10);
    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
    SET generatedGameId = (SELECT GenerateGameId());
    SET userToken = concat(generatedGameId, '_', pName);
    SET tokenColor = 'red';
    SET userTurn = 'enable';
	
    START TRANSACTION;
		INSERT INTO tblGameDetail (gameId, gameHost) VALUES (generatedGameId, pName);
		INSERT INTO tblGamePlayer (userTokenId, username, gameId, userTurn) VALUES (userToken, pName, generatedGameId, userTurn); 
		CALL InsertObstacleDetail(generatedGameId);
		INSERT INTO tblUserMovement (userTokenId, gameId, tokenColor) VALUES (userToken, generatedGameId, tokenColor);
		SELECT generatedGameId, tokenColor, userTurn;
	COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteUser`(pName VARCHAR(50))
BEGIN
	DECLARE status VARCHAR(50);
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
    START TRANSACTION;
		SELECT accountStatus FROM tblAccount WHERE username = pName INTO status;
		IF status = 'locked' OR status = 'offline' THEN
			DELETE FROM tblAccount WHERE username = pName;
			SELECT 'Player removed successfully.' AS MESSAGE;
		ELSEIF status = 'playing' THEN
			SELECT 'The selected player is playing. You cannot remove at this stage.' AS MESSAGE;
		ELSE	
			SELECT 'You cannot remove the player at this stage.' AS MESSAGE;
		END IF;
	COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ExitGame`(pGameId INTEGER, pName VARCHAR(50))
BEGIN
    DECLARE userToken VARCHAR(100);
    DECLARE gameScore INTEGER;
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
    SET userToken = concat(pGameId, '_', pName);
    START TRANSACTION;
		IF (SELECT playerCount FROM tblGameDetail WHERE gameId = pGameId) > 2 THEN
			SELECT score FROM tblGamePlayer WHERE userTokenId = userToken INTO gameScore;
			UPDATE tblAccount 
				SET accountStatus='online',
				highScore = CASE WHEN gameScore > highScore THEN gameScore
								 WHEN gameScore <= highScore THEN highScore
								 END
				WHERE username = pName;					
			UPDATE tblGamePlayer SET userTurn = 'playerQuit' WHERE userTokenId = userToken;
			UPDATE tblGameDetail SET playerCount = playerCount - 1 WHERE gameId = pGameId;
            DELETE FROM tblUserMovement WHERE userTokenId = userToken;
			SELECT 'Successfully quit' AS MESSAGE;
		ELSE
			SELECT 'Atleast 2 players required to continue the game. please finish the game' AS MESSAGE;
		END IF;
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `GenerateDiceRollOutput`(pGameId INTEGER, pUsername VARCHAR(50))
BEGIN
    DECLARE rollResult INTEGER;
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
    START TRANSACTION;
		IF (SELECT playerCount FROM tblGameDetail WHERE gameId = pGameId) > 1 THEN
			IF 'enable' = (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = concat(pGameId, '_', pUsername)) THEN
				SET rollResult = round(RAND() * (5)) + 1;
				INSERT INTO tblDiceRoll (gameId, rollResult) VALUES(pGameId, rollResult);
				UPDATE tblGameDetail SET gameStatus = 'running' WHERE gameId = pGameId;
				SELECT rollResult AS ROLLRESULT;
			ELSE
				SELECT 'Not you turn' AS ROLLRESULT;
			END IF;
		ELSE
			SELECT 'Atleast 2 players required to start the game.' AS ROLLRESULT;
		END IF;
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetGameBoardDetails`(pGameId INTEGER)
BEGIN
	SELECT obstaclePosition, tokenColor FROM tblUserMovement WHERE gameID = pGameId;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetGameList`()
BEGIN
	SELECT gameHost AS Host, gameId AS GameId, gameStatus AS Status 
    FROM tblGameDetail 
    ORDER BY gameStatus ASC;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetGameListForAdmin`()
BEGIN
	SELECT gameHost AS Host, gameId AS GameId, gameStatus AS Status, playerCount AS PlayerCount
    FROM tblGameDetail 
    ORDER BY gameStatus ASC;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetGameRoomScoreList`(pGameId INTEGER)
BEGIN
	SELECT username, score, userTurn FROM tblGamePlayer WHERE gameId = pGameId AND userTurn != 'playerQuit';
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetGameStatus`(pGameId INTEGER)
BEGIN
	DECLARE gameStat VARCHAR(20);
	SELECT gameStatus FROM tblGameDetail WHERE gameId = pGameId INTO gameStat;
    IF 'terminated' = gameStat THEN
		SELECT 'Game Terminated. Please click OK to go to dashboard.' AS MESSAGE;
	ELSEIF 'finished' = gameStat THEN
		SELECT 'Game Finished. Please click OK to go to dashboard.' AS MESSAGE;
	ELSE	
		SELECT 'continue' AS MESSAGE;
	END IF;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetOnlinePlayerList`()
BEGIN
	SELECT username AS Player, highScore AS Score 
    FROM tblAccount 
	WHERE accountStatus = 'online' OR accountStatus = 'playing' 
    ORDER BY highScore DESC;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetPlayerListForAdmin`()
BEGIN
	SELECT username AS Player, highScore AS Score , accountStatus as AccountStatus
    FROM tblAccount 
    ORDER BY userName ASC;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertObstacleDetail`(pGameId INTEGER)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
	INSERT INTO tblObstacleDetail (obstaclePosition, gameId, obstaclePurpose)
		VALUES (0, pGameId, 'start'), (1, pGameId, 'stay'), (2, pGameId, 'stay'), (3, pGameId, 'restart'),
			(4, pGameId, 'stepBack'), (5, pGameId, 'stay'), (6, pGameId, 'stepInTwice'), (7, pGameId, 'stay'),
			(8, pGameId, 'stay'), (9, pGameId, 'stepBack'), (10, pGameId, 'stepIn'), (11, pGameId, 'stay'),
			(12, pGameId, 'mysteryWheel'), (13, pGameId, 'stay'), (14, pGameId, 'stepBack'), (15, pGameId, 'stepIn'),
			(16, pGameId, 'stay'), (17, pGameId, 'stay'), (18, pGameId, 'stepInTwice'), (19, pGameId, 'stay'),
			(20, pGameId, 'restart'), (21, pGameId, 'stay'), (22, pGameId, 'stepInTwice'), (23, pGameId, 'stay'),
			(24, pGameId, 'finish');
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `JoinGame`(pGameId INTEGER, pName VARCHAR(50))
BEGIN
	DECLARE status VARCHAR(50);
    DECLARE gameCount INTEGER;
    DECLARE existingPlayerCount INTEGER;
    DECLARE userToken VARCHAR(100);
    DECLARE userTurn VARCHAR(10);
    DECLARE tokenColor VARCHAR(10);
    DECLARE alreadyInGameCount INTEGER;
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
	START TRANSACTION;
		SELECT COUNT(gameId)  FROM tblGameDetail WHERE gameId = pGameId INTO gameCount;
		IF 1 = gameCount THEN
			SET userToken = concat(pGameId, '_', pName);
			SET userTurn = 'disable';
			SELECT gameStatus, playerCount FROM tblGameDetail WHERE gameId = pGameId INTO status, existingPlayerCount;
			IF 4 = existingPlayerCount THEN
				SELECT 'Maximum allowed players reached' AS MESSAGE;
			ELSEIF 'waitingToStart' = status OR 'running' = status THEN
				SELECT COUNT(username) FROM tblGamePlayer WHERE gameId = pGameId AND username = pName INTO alreadyInGameCount;
				IF 1 = alreadyInGameCount THEN 
					SELECT 'You have been to this game before. Once quit, cannot enter again.' AS MESSAGE;
				ELSE
					SET tokenColor = (SELECT GetTokenColor(pGameId));
					UPDATE tblGameDetail SET playerCount = playerCount + 1 WHERE gameId = pGameId;
					INSERT INTO tblGamePlayer (userTokenId, username, gameId, userTurn) VALUES (userToken, pName, pGameId, userTurn); 
					INSERT INTO tblUserMovement (userTokenId, gameId, tokenColor) VALUES (userToken, pGameId, tokenColor);
					SELECT pGameId, tokenColor, userTurn;
				END IF;
			ELSEIF 'finished' = status THEN
				SELECT 'game finished' AS MESSAGE;
			ELSE
				SELECT 'game terminated' AS MESSAGE;
			END IF;
		ELSE 
			SELECT 'invalid gameId' AS MESSAGE;
		END IF;
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `LogOutSession`(pName VARCHAR(50))
BEGIN
	UPDATE tblAccount 
    SET accountStatus='offline' 
    WHERE username = pName;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ResetPassword`(pName VARCHAR(50), pPassword VARCHAR(50))
BEGIN
	DECLARE oldPassword VARCHAR(50);
    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
    SELECT userPassword FROM tblAccount WHERE username = pName into oldPassword;
    IF oldPassword = pPassword THEN
		SELECT "Please use a new password." AS MESSAGE;
	ELSE
		UPDATE tblAccount SET userPassword = pPassword WHERE username = pName;
        SELECT "Password reset successfully." AS MESSAGE;
    END IF;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `TerminateGame`(pGameId INTEGER)
BEGIN
	DECLARE status VARCHAR(50);
    DECLARE highScore INTEGER;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
	SELECT gameStatus FROM tblGameDetail WHERE gameId = pGameId INTO status;
    
    IF status = 'running' THEN
		SELECT MAX(score) FROM tblGamePlayer WHERE gameId = pGameId INTO highScore;
        UPDATE tblGameDetail SET gameHighScore = highScore, gameStatus = 'terminated' WHERE gameId = pGameId;
        SELECT 'Game terminated successfully.' AS MESSAGE;
	ELSE
		SELECT 'Not a live game. Hence cannot terminate.' AS MESSAGE;
	END IF;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `UnLockUser`(pName VARCHAR(50))
BEGIN
	DECLARE status VARCHAR(50);
    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
    START TRANSACTION;
		SELECT accountStatus FROM tblAccount WHERE username = pName INTO status;
		IF status = 'locked' THEN
			UPDATE tblAccount SET accountStatus = 'offline', loginAttemptCount = 0 WHERE username = pName;
			SELECT 'Account un-locked successfully' AS MESSAGE;
		ELSE	
			SELECT 'The selected account is not locked.' AS MESSAGE;
		END IF;
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePlayerPosition`(pGameId INTEGER, pRollResult INTEGER, pUsername VARCHAR(50))
BEGIN
	DECLARE currentScore INTEGER;
    DECLARE currentPosition INTEGER;
    DECLARE finalPosition INTEGER;
	DECLARE userToken VARCHAR(100);
    DECLARE nextUserTurn VARCHAR(10);
    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
    SET userToken = concat(pGameId, '_', pUsername);
    
    START TRANSACTION;
		IF (SELECT playerCount FROM tblGameDetail WHERE gameId = pGameId) > 1 THEN
			IF 'enable' = (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = userToken) THEN
				SELECT userPosition FROM tblUserMovement WHERE userTokenId = userToken INTO currentPosition;
				SET finalPosition = (SELECT CalculateNewPosition(currentPosition, pGameId, pRollResult));
				UPDATE tblGamePlayer SET score = finalPosition, userTurn = 'disable' WHERE userTokenId = userToken;
				UPDATE tblUserMovement SET obstaclePosition = finalPosition, userPosition = finalPosition WHERE userTokenId = userToken;
				IF 24 = finalPosition THEN
					UPDATE tblGameDetail SET winner = pUsername, gameHighScore = finalPosition, gameStatus = 'finished' WHERE gameId = pGameId;
					CALL UpdateWhenGameFinish(pGameId, 'finished');
					SELECT 'WINNER' as MESSAGE;
				ELSE 
					UPDATE tblGameDetail SET gameStatus = 'running' WHERE gameId = pGameId;
					CALL UpdateWhenGameFinish(pGameId, 'running');
					SET nextUserTurn = (SELECT GetNextUserTurn(pGameId, (SELECT tokenColor FROM tblUserMovement WHERE userTokenId = userToken)));
					SELECT pUsername, userPosition, tokenColor, nextUserTurn FROM tblUserMovement WHERE userTokenId = userToken;
				END IF;
			ELSE
				SELECT 'Please wait for your turn.' AS MESSAGE;
			END IF;
		ELSE
			SELECT 'Atleast 2 players required.' AS MESSAGE;
		END IF;
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateWhenGameFinish`(pGameId INTEGER, pGameStatus VARCHAR(10))
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		SHOW ERRORS LIMIT 1;
		ROLLBACK;
    END;
    DECLARE EXIT HANDLER for SQLWARNING
	BEGIN
		ROLLBACK;
		SHOW WARNINGS LIMIT 1;
	END;
	START TRANSACTION;
		UPDATE tblAccount
		INNER JOIN tblGamePlayer ON tblAccount.username = tblGamePlayer.username AND tblGamePlayer.gameId = pGameId
		SET tblAccount.highScore = IF(tblGamePlayer.score > tblAccount.highScore, tblGamePlayer.score, tblAccount.highScore),
			tblAccount.gamesWon = IF(tblGamePlayer.score = 24, tblAccount.gamesWon + 1, tblAccount.gamesWon),
			tblAccount.gamesPlayed = IF(pGameStatus = 'finished', tblAccount.gamesPlayed + 1, tblAccount.gamesPlayed),
			tblAccount.accountStatus = IF(pGameStatus = 'finished', 'online', tblAccount.accountStatus),
			tblGamePlayer.userTurn = 'disable'    
		WHERE tblGamePlayer.gameId = pGameId;
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateNewPosition`(pCurrentPosition INTEGER, pGameId INTEGER, pRollResult INTEGER) RETURNS int(11)
    DETERMINISTIC
	BEGIN
	DECLARE newPosition INTEGER;
	DECLARE obstaclePurp VARCHAR(50);
    DECLARE tempNewPosition INTEGER;
    
    SET tempNewPosition = pCurrentPosition + pRollResult;
    
	IF tempNewPosition > 24 THEN 
		RETURN pCurrentPosition;
	ELSE 
		SELECT obstaclePurpose FROM tblObstacleDetail WHERE obstaclePosition = tempNewPosition AND gameId = pGameId INTO obstaclePurp;
		IF 'stay' = obstaclePurp THEN
			SET newPosition = tempNewPosition;
		ELSEIF 'restart' = obstaclePurp THEN
			SET newPosition = 0;
		ELSEIF 'stepBack' = obstaclePurp THEN
			SET newPosition = tempNewPosition - 1;
		ELSEIF 'stepInTwice' = obstaclePurp THEN
			SET newPosition = tempNewPosition + 2;
		ELSEIF 'finish' = obstaclePurp THEN
			SET newPosition = 24;
		ELSEIF 'stepIn' = obstaclePurp THEN
			SET newPosition = tempNewPosition + 1;
		ELSEIF 'mysteryWheel' = obstaclePurp THEN
			SET @mysteryObstacle = (SELECT ELT(0.5 + (RAND() * 4), 'restart', 'finish', 'stepIn', 'stepBack'));
            IF 'restart' = @mysteryObstacle THEN
				SET newPosition = 0;
			ELSEIF 'finish' = @mysteryObstacle THEN 
				SET newPosition = 24;
			ELSEIF 'stepIn' = @mysteryObstacle THEN
				SET newPosition = tempNewPosition + 1;
			ELSEIF 'stepBack' = @mysteryObstacle THEN
				SET newPosition = tempNewPosition - 1;
			END IF;
		END IF;
	END IF;
    
    IF newPosition > 24 THEN 
		RETURN pCurrentPosition;
	ELSE
		RETURN newPosition;
	END IF;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` FUNCTION `GenerateGameId`() RETURNS int(11)
    DETERMINISTIC
	BEGIN
	DECLARE randomGameId INTEGER;
    DECLARE gameIdCount INTEGER DEFAULT 1;
    
    
    WHILE gameIdCount = 1 DO
		SET randomGameId = round(RAND() * 10000) + 9999;
		SELECT count(gameId) FROM tblGameDetail WHERE gameId = randomGameId INTO gameIdCount;
		IF 0 = gameIdCount THEN
			SET gameIdCount = 1;
			RETURN randomGameId;
        END IF;
	END WHILE;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` FUNCTION `GetNextUserTurn`(pGameId INTEGER, pCurrentTokenColor VARCHAR(10)) RETURNS varchar(10) CHARSET utf8mb4
    DETERMINISTIC
BEGIN
	DECLARE nextTokenColor VARCHAR(10);
    DECLARE userToken VARCHAR(100);
    
    IF 'red' = pCurrentTokenColor THEN
		IF (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = (SELECT userTokenId FROM tblUserMovement 
										WHERE gameId = pGameId AND tokenColor = 'green')) != 'playerQuit' THEN
			SET nextTokenColor = 'green';
		ELSEIF (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = (SELECT userTokenId FROM tblUserMovement 
										WHERE gameId = pGameId AND tokenColor = 'blue')) != 'playerQuit' THEN
			SET nextTokenColor = 'blue';
		ELSEIF (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = (SELECT userTokenId FROM tblUserMovement 
										WHERE gameId = pGameId AND tokenColor = 'black')) != 'playerQuit' THEN
			SET nextTokenColor = 'black';
		END IF;
	ELSEIF 'green' = pCurrentTokenColor THEN
		IF (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = (SELECT userTokenId FROM tblUserMovement 
										WHERE gameId = pGameId AND tokenColor = 'blue')) != 'playerQuit' THEN
			SET nextTokenColor = 'blue';
		ELSEIF (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = (SELECT userTokenId FROM tblUserMovement 
										WHERE gameId = pGameId AND tokenColor = 'black')) != 'playerQuit' THEN
			SET nextTokenColor = 'black';
		ELSEIF (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = (SELECT userTokenId FROM tblUserMovement 
										WHERE gameId = pGameId AND tokenColor = 'red')) != 'playerQuit' THEN
			SET nextTokenColor = 'red';
		END IF;
	ELSEIF 'blue' = pCurrentTokenColor THEN
		IF (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = (SELECT userTokenId FROM tblUserMovement 
										WHERE gameId = pGameId AND tokenColor = 'black')) != 'playerQuit' THEN
			SET nextTokenColor = 'black';
		ELSEIF (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = (SELECT userTokenId FROM tblUserMovement 
										WHERE gameId = pGameId AND tokenColor = 'red')) != 'playerQuit' THEN
			SET nextTokenColor = 'red';
		ELSEIF (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = (SELECT userTokenId FROM tblUserMovement 
										WHERE gameId = pGameId AND tokenColor = 'green')) != 'playerQuit' THEN
			SET nextTokenColor = 'green';
		END IF;
	ELSEIF 'black' = pCurrentTokenColor THEN
		IF (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = (SELECT userTokenId FROM tblUserMovement 
										WHERE gameId = pGameId AND tokenColor = 'red')) != 'playerQuit' THEN
			SET nextTokenColor = 'red';
		ELSEIF (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = (SELECT userTokenId FROM tblUserMovement 
										WHERE gameId = pGameId AND tokenColor = 'green')) != 'playerQuit' THEN
			SET nextTokenColor = 'green';
		ELSEIF (SELECT userTurn FROM tblGamePlayer WHERE userTokenId = (SELECT userTokenId FROM tblUserMovement 
										WHERE gameId = pGameId AND tokenColor = 'blue')) != 'playerQuit' THEN
			SET nextTokenColor = 'blue';
		END IF;
	END IF;
    
    SET userToken = (SELECT userTokenId FROM tblUserMovement WHERE gameId = pGameId AND tokenColor = nextTokenColor);
    UPDATE tblGamePlayer SET userTurn = 'enable' WHERE userTokenId = userToken;
    
	RETURN (SELECT username FROM tblGamePlayer WHERE userTokenId = userToken);
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` FUNCTION `GetTokenColor`(pGameId INTEGER) RETURNS varchar(10) CHARSET utf8mb4
    DETERMINISTIC
	BEGIN
	DECLARE isRedPlayerExists INTEGER DEFAULT 0;
    DECLARE isGreenPlayerExists INTEGER DEFAULT 0;
    DECLARE isBluePlayerExists INTEGER DEFAULT 0;
    DECLARE isBlackPlayerExists INTEGER DEFAULT 0;
	
    SELECT COUNT(tokenColor) FROM tblUserMovement WHERE gameId = pGameId AND tokenColor = 'red' INTO isRedPlayerExists;
    IF isRedPlayerExists = 0 THEN
		RETURN 'red';
	END IF;
    SELECT COUNT(tokenColor) FROM tblUserMovement WHERE gameId = pGameId AND tokenColor = 'green' INTO isGreenPlayerExists;
    IF isGreenPlayerExists = 0 THEN
		RETURN 'green';
	END IF;
    SELECT COUNT(tokenColor) FROM tblUserMovement WHERE gameId = pGameId AND tokenColor = 'blue' INTO isBluePlayerExists;
	IF isBluePlayerExists = 0 THEN
		RETURN 'blue';
	END IF;
    SELECT COUNT(tokenColor) FROM tblUserMovement WHERE gameId = pGameId AND tokenColor = 'black' INTO isBlackPlayerExists;
    IF isBlackPlayerExists = 0 THEN
		RETURN 'black';
    END IF;
END //
DELIMITER ;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertSampleData`()
BEGIN
		-- tblAccount - Adding admin and other players
		INSERT INTO tblAccount (username,userPassword,emailId,highScore,gamesPlayed,gamesWon,isAdmin,lastLogin,sessionCount,loginAttemptCount,accountStatus) 
			VALUES ("achu","achu","achu12@gmail.com",24,2,2,"yes","2019-05-21 10:43:27",15,0,"online"),
				("manu","manu","manu123@gmail.com",16,3,0,"no","2019-05-20 05:55:56",6,0,"offline"),
				("iren","iren","iren123@gmail.com",16,5,2,"no","2019-05-17 13:07:01",6,0,"offline"),
				("akhil","akhil","akhil@gmail.com",24,6,1,"no","2019-05-21 09:16:04",6,5,"locked"),
                ("james","james","james@gmail.com",17,3,0,"no","2019-05-21 09:16:04",6,5,"locked"),
                ("simi","simi","simi@gmail.com",10,2,0,"no","2019-05-21 09:16:04",6,5,"locked"),
				("john","john","john@gmail.com",13,3,0,"no","2019-05-17 19:49:12",6,0,"online");
			 
		-- tblGameDetail - Creating some games
		INSERT INTO tblGameDetail (gameId, gameHost, playerCount, winner, gameHighScore, gameStatus)
			VALUES (2212, 'achu', 4, 'achu',  24, 'finished'), (2334, 'iren', 3, 'achu', 24,  'finished'),
				(4543, 'james', 2, NULL,  0, 'terminated'), (1234, 'simi', 3, NULL, 0,  'terminated'),
				(9873, 'john', 2, 'iren',  24, 'finished'), (9878, 'john', 3, 'iren', 24,  'finished');

		-- tblGamePlayer - Adding some player data related to the games
		INSERT INTO tblGamePlayer (userTokenId, username, gameId, playDate, userTurn, score)
			VALUES ('2212_achu', 'achu', '2212', '2019-05-20 06:55:56', 'enable', 24), ('2212_iren', 'iren', '2212', '2019-05-20 06:56:56', 'disable', 13),
				('2212_james', 'james', '2212', '2019-05-20 06:55:56', 'disable', 11), ('2212_john', 'john', '2212', '2019-05-20 06:55:56', 'disable', 11),
				('2334_achu', 'achu', '4543', '2019-05-21 06:55:56', 'enable', 19), ('2334_akhil', 'akhil', '4543', '2019-05-21 06:55:56', 'disable', 24);

		-- tblObstacleDetail - Defining the Obstacle position and obstacle purpose in each game
		INSERT INTO tblObstacleDetail (obstaclePosition, gameId, obstaclePurpose)
		VALUES (0, 2212, 'start'), (1, 2212, 'stay'), (2, 2212, 'stay'), (3, 2212, 'restart'),
			(4, 2212, 'stepBack'), (5, 2212, 'stay'), (6, 2212, 'stepInTwice'), (7, 2212, 'stay'),
			(8, 2212, 'stay'), (9, 2212, 'stepBack'), (10, 2212, 'stepIn'), (11, 2212, 'stay'),
			(12, 2212, 'mysteryWheel'), (13, 2212, 'stay'), (14, 2212, 'stepBack'), (15, 2212, 'stepIn'),
			(16, 2212, 'stay'), (17, 2212, 'stay'), (18, 2212, 'stepInTwice'), (19, 2212, 'stay'),
			(20, 2212, 'restart'), (21, 2212, 'stay'), (22, 2212, 'stepInTwice'), (23, 2212, 'stay'),
			(24, 2212, 'finish'),
            (0, 2334, 'start'), (1, 2334, 'stay'), (2, 2334, 'stay'), (3, 2334, 'restart'),
			(4, 2334, 'stepBack'), (5, 2334, 'stay'), (6, 2334, 'stepInTwice'), (7, 2334, 'stay'),
			(8, 2334, 'stay'), (9, 2334, 'stepBack'), (10, 2334, 'stepIn'), (11, 2334, 'stay'),
			(12, 2334, 'mysteryWheel'), (13, 2334, 'stay'), (14, 2334, 'stepBack'), (15, 2334, 'stepIn'),
			(16, 2334, 'stay'), (17, 2334, 'stay'), (18, 2334, 'stepInTwice'), (19, 2334, 'stay'),
			(20, 2334, 'restart'), (21, 2334, 'stay'), (22, 2334, 'stepInTwice'), (23, 2334, 'stay'),
			(24, 2334, 'finish'),
            (0, 9873, 'start'), (1, 9873, 'stay'), (2, 9873, 'stay'), (3, 9873, 'restart'),
			(4, 9873, 'stepBack'), (5, 9873, 'stay'), (6, 9873, 'stepInTwice'), (7, 9873, 'stay'),
			(8, 9873, 'stay'), (9, 9873, 'stepBack'), (10, 9873, 'stepIn'), (11, 9873, 'stay'),
			(12, 9873, 'mysteryWheel'), (13, 9873, 'stay'), (14, 9873, 'stepBack'), (15, 9873, 'stepIn'),
			(16, 9873, 'stay'), (17, 9873, 'stay'), (18, 9873, 'stepInTwice'), (19, 9873, 'stay'),
			(20, 9873, 'restart'), (21, 9873, 'stay'), (22, 9873, 'stepInTwice'), (23, 9873, 'stay'),
			(24, 9873, 'finish'),
            (0, 9878, 'start'), (1, 9878, 'stay'), (2, 9878, 'stay'), (3, 9878, 'restart'),
			(4, 9878, 'stepBack'), (5, 9878, 'stay'), (6, 9878, 'stepInTwice'), (7, 9878, 'stay'),
			(8, 9878, 'stay'), (9, 9878, 'stepBack'), (10, 9878, 'stepIn'), (11, 9878, 'stay'),
			(12, 9878, 'mysteryWheel'), (13, 9878, 'stay'), (14, 9878, 'stepBack'), (15, 9878, 'stepIn'),
			(16, 9878, 'stay'), (17, 9878, 'stay'), (18, 9878, 'stepInTwice'), (19, 9878, 'stay'),
			(20, 9878, 'restart'), (21, 9878, 'stay'), (22, 9878, 'stepInTwice'), (23, 9878, 'stay'),
			(24, 9878, 'finish');

		-- tblMysteryWheel - Generating the output of mystery wheel or each game when required
		INSERT INTO tblMysteryWheel (gameId, obstaclePosition, wheelResult)
			VALUES (2212, 12, 'stepInTwice'), (2334, 12, 'stepBack'), (2334, 12, 'stepInTwice'), (2212, 12, 'stepBack'),
			(2212, 12, 'stepInTwice'), (2334, 12, 'restart'), (2212, 12, 'stepInTwice'), (2334, 12, 'stepInTwice');

		-- tblDiceRoll - Generating the output when a dice is rolled each time in each game
		INSERT INTO tblDiceRoll (gameId, rollResult)
			VALUES (2212, 3), (2212, 2), (2212, 2), (2212, 1), (2212, 4), (2212, 5), (2212, 4), (2212, 1), (2212, 6),
				(2212, 1), (2212, 1), (2212, 1), (2212, 2), (2212, 3), (2212, 4), (2212, 4), (2212, 6), (2212, 6),
				(2212, 6), (2212, 2), (2212, 5), (2212, 5), (2212, 4), (2212, 3), (2212, 6), (2212, 6), (2212, 1),
				(2212, 3), (2212, 4), (2212, 5), (2212, 4), (2212, 1), (2212, 1), (2212, 2), (2212, 3), (2212, 3),
				(4543, 6), (4543, 6), (4543, 2), (4543, 5), (4543, 6), (4543, 3), (4543, 2), (4543, 4), (4543, 3),
				(4543, 1), (4543, 3), (4543, 1), (4543, 5), (4543, 4), (4543, 3), (4543, 1), (4543, 6), (4543, 6),
				(4543, 1), (4543, 3), (4543, 4), (4543, 3), (4543, 2), (4543, 5), (4543, 4), (4543, 2), (4543, 4);

		-- tblUserMovement - Tracking the movement of each player corresponding to the game
		INSERT INTO tblUserMovement (userTokenId, gameId, obstaclePosition, userPosition, tokenColor)
			VALUES ('2212_achu', 2212, 18, 18, 'green'), ('2212_james', 2212, 10, 10, 'blue'), ('2212_iren', 2212, 21, 21, 'red'), ('2212_john', 2212, 6, 6, 'black'),
				('2334_achu', 2334, 18, 18, 'red'), ('2334_akhil',2334, 10, 10, 'blue');
END //
DELIMITER ;


CALL DropTables();
CALL CreateGameTables();
CALL InsertSampleData();


