CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Flights` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DepartureCity` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ArrivalCity` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Duration` int NOT NULL,
    `Price` double NOT NULL,
    `Capacity` int NOT NULL,
    CONSTRAINT `PK_Flights` PRIMARY KEY (`Id`)
);

CREATE TABLE `Passenger` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FirstName` longtext CHARACTER SET utf8mb4 NOT NULL,
    `LastName` longtext CHARACTER SET utf8mb4 NOT NULL,
    `FlightId` int NULL,
    CONSTRAINT `PK_Passenger` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Passenger_Flights_FlightId` FOREIGN KEY (`FlightId`) REFERENCES `Flights` (`Id`) ON DELETE RESTRICT
);

CREATE INDEX `IX_Passenger_FlightId` ON `Passenger` (`FlightId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240311010849_ApplicationContextSnapshot', '3.1.32');

