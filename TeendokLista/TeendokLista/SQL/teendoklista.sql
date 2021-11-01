-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2021. Nov 01. 11:14
-- Kiszolgáló verziója: 10.4.21-MariaDB
-- PHP verzió: 7.4.23

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `teendoklista`
--
CREATE DATABASE IF NOT EXISTS `teendoklista` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `teendoklista`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `feladatok`
--

CREATE TABLE `feladatok` (
  `Id` int(11) NOT NULL,
  `Cim` varchar(50) NOT NULL,
  `Szoveg` text NOT NULL,
  `Hatarido` datetime(6) NOT NULL,
  `Teljesitve` tinyint(1) NOT NULL,
  `FelhasznaloId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `feladatok`
--

INSERT INTO `feladatok` (`Id`, `Cim`, `Szoveg`, `Hatarido`, `Teljesitve`, `FelhasznaloId`) VALUES
(1, 'Első feladat', 'Tervezés', '2021-10-08 00:00:00.000000', 0, 1),
(2, 'Második feladat', 'Megvalósítás', '2021-10-31 00:00:00.000000', 1, 1),
(3, 'Próba', 'Teszt', '2021-11-01 10:56:44.854327', 0, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalok`
--

CREATE TABLE `felhasznalok` (
  `Id` int(11) NOT NULL,
  `Felhasznalonev` varchar(50) NOT NULL,
  `Jelszo` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `felhasznalok`
--

INSERT INTO `felhasznalok` (`Id`, `Felhasznalonev`, `Jelszo`) VALUES
(1, 'admin', '$2a$11$JGsKig5QYjhqiN/oxH.MP.aTIq3Hklv1gjOUJ/PDz.QRPd06lqqfm'),
(2, 'user', '$2a$11$qdlO060ZqGVD75J0kD2IY.fwBUXT.9o47HofNaoWuTic2t0il8XMq');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `feladatok`
--
ALTER TABLE `feladatok`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Feladatok_FelhasznaloId` (`FelhasznaloId`);

--
-- A tábla indexei `felhasznalok`
--
ALTER TABLE `felhasznalok`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_Felhasznalok_Felhasznalonev` (`Felhasznalonev`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `feladatok`
--
ALTER TABLE `feladatok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `felhasznalok`
--
ALTER TABLE `felhasznalok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `feladatok`
--
ALTER TABLE `feladatok`
  ADD CONSTRAINT `FK_Feladatok_Felhasznalok_FelhasznaloId` FOREIGN KEY (`FelhasznaloId`) REFERENCES `felhasznalok` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
