-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Feb 13, 2026 at 12:45 PM
-- Server version: 8.0.42
-- PHP Version: 8.2.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ingatlan_2`
--
CREATE DATABASE IF NOT EXISTS `ingatlan_2` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `ingatlan_2`;

-- --------------------------------------------------------

--
-- Table structure for table `ingatlanok`
--

CREATE TABLE `ingatlanok` (
  `id` bigint UNSIGNED NOT NULL,
  `kategoria` bigint UNSIGNED NOT NULL,
  `leiras` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `hirdetesdatuma` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `tehermentes` tinyint(1) NOT NULL,
  `ar` int NOT NULL,
  `kepUrl` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `ingatlanok`
--

INSERT INTO `ingatlanok` (`id`, `kategoria`, `leiras`, `hirdetesdatuma`, `tehermentes`, `ar`, `kepUrl`) VALUES
(1, 1, 'Kertvárosi részén, egyszintes házat kínálunk nyugodt környezetben, nagy telken.', '2022-03-08 23:00:00', 1, 26990000, 'https://cdn.jhmrad.com/wp-content/uploads/three-single-storey-houses-elegance-amazing_704000.jpg'),
(2, 1, 'Belvárosi környezetben, árnyékos helyen kis méretú családi ház eladó. Tömegközlekedéssel könnyen megközelíthető.', '2022-03-15 23:00:00', 1, 28990000, 'https://www.westsideseattle.com/sites/default/files/styles/news_teaser/public/images/archive/ballardnewstribune.com/content/articles/2008/11/21/features/columnists/column07.jpg?itok=wMrlOwFU'),
(3, 2, 'Kétszintes berendezett lakás a belvárosban kiadó.', '2022-03-11 23:00:00', 1, 32000000, 'https://images.unsplash.com/photo-1606074280798-2dabb75ce10c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=735&q=80'),
(4, 4, 'Nagy garázs kertvárosi környezetben kiadó.', '2022-03-13 23:00:00', 1, 5990000, 'https://www.afritechmedia.com/wp-content/uploads/2021/11/How-Can-You-Protect-Your-Garage-Floor-612x340.jpg'),
(5, 5, '10 hektáros mezőhazdasági terület eladó.', '2022-03-17 23:00:00', 1, 79000000, 'https://i2-prod.manchestereveningnews.co.uk/incoming/article18411144.ece/ALTERNATES/s810/0_gettyimages-1151774950-170667a.jpg'),
(6, 6, 'Felújításra szoruló üzemcsarnok zöld környezetben áron alul eladó.', '2022-03-10 23:00:00', 0, 25000000, 'https://cdn.pixabay.com/photo/2019/01/31/09/24/urban-3966306_960_720.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `kategoriak`
--

CREATE TABLE `kategoriak` (
  `id` bigint UNSIGNED NOT NULL,
  `nev` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `kategoriak`
--

INSERT INTO `kategoriak` (`id`, `nev`) VALUES
(1, 'Ház'),
(2, 'Lakás'),
(3, 'Építési telek'),
(4, 'Garázs'),
(5, 'Mezőgazdasági terület'),
(6, 'Ipari ingatlan');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ingatlanok`
--
ALTER TABLE `ingatlanok`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ingatlanok_kategoria_foreign` (`kategoria`);

--
-- Indexes for table `kategoriak`
--
ALTER TABLE `kategoriak`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `ingatlanok`
--
ALTER TABLE `ingatlanok`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `kategoriak`
--
ALTER TABLE `kategoriak`
  MODIFY `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ingatlanok`
--
ALTER TABLE `ingatlanok`
  ADD CONSTRAINT `ingatlanok_kategoria_foreign` FOREIGN KEY (`kategoria`) REFERENCES `kategoriak` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
