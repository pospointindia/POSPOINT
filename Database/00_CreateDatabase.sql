-- POSPOINT Database Creation Script
-- Multi-Location Retail ERP System

-- Create Database
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'POSPOINT')
    CREATE DATABASE POSPOINT;
GO

USE POSPOINT;
GO

PRINT 'Database POSPOINT created successfully';
