# HotelMangement.System
This is a hotel management system where a customer checks for hotels available, signs up and makes some booking. This system API captures the customers records,makes sure it does not already exist and then stores it in the database. It is build with N-Layered architecture where all folders are created under one Asp.Net API Framework.

This project contains :
Models which contains the database models like Customer,Role,Employee,Hotel,Room,Bookings.
DTO which is the Data Transfer object. Responsibel for displaying or abstracting fields to the UI. It was used to abstract sensitive fields like the CustomerID and password. It was equall used across all other models .

Base Entity was alaso used to accomodate properties common across other derived models which they can inherit.

Features

Hotel Management
Create Hotel--Here the Admin or anyone saddled with the responsibility(through roles) uploads or creates hotels into the database. 
Retrieve Hotel--- Reads or fetches hotels by their uniqueID.
Update Hotel modify existing hotel records
Delete Hotel it makes use of soft delete where the record is not really deleted but just marked. This is really necesary for accountability sake. 

Repository pattern is also used in this project.

