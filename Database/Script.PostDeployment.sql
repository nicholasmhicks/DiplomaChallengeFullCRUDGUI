/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF '$(LoadTestData)' = 'true'

BEGIN

DELETE FROM Bookings;

DELETE FROM TourEvents;

DELETE FROM Tours;

DELETE FROM Clients;

INSERT INTO Clients(ClientId,Surname,GivenName,Gender)
VALUES
(1, 'Price', 'Taylor', 'M'),
(2, 'Gamble', 'Ellyse', 'F'),
(3, 'Tan', 'Tilly', 'F');

INSERT INTO Tours(TourName, Description)
VALUES
('West', 'Tour of wineries and outlets of the Geelong and Otways region'),
('East', 'Tour of wineries and outlets of the Yarra Valley'),
('South', 'Tour of wineries and outlets of Mornington Penisula'),
('North', 'Tour of wineries and outlets of the Bedigo and Castlemaine region');


INSERT INTO TourEvents(EventMonth,EventDay,EventYear,TourName,Fee)
VALUES
('Jan', '9', '2016', 'North', 200),
('Feb', '13', '2016', 'North', 225),
('Jan', '16', '2016', 'South', 200),
('Jan', '29', '2016', 'North', 225);

INSERT INTO Bookings(BookingId, ClientId, TourName, EventMonth, EventDay,EventYear,Payment,DateBooked)
VALUES
(1, 1, 'North', 'Jan', '9', '2016', 200, '10/12/2015'),
(2, 2, 'North', 'Jan', '9', '2016', 200, '16/12/2015'),
(3, 1, 'North', 'Feb', '13', '2016', 225, '8/01/2016'),
(4, 2, 'North', 'Feb', '13', '2016', 225, '14/01/2016'),
(5, 3, 'North', 'Feb', '13', '2016', 225, '3/02/2016'),
(6, 1, 'South', 'Jan', '16', '2016', 200, '10/12/2015'),
(7, 2, 'South', 'Jan', '16', '2016', 200, '18/12/2015'),
(8, 3, 'South', 'Jan', '9', '2016', 200, '09/01/2016'),
(9, 2, 'West', 'Jan', '29', '2016', 200, '17/12/2015'),
(10, 3, 'West', 'Jan', '29', '2016', 200, '18/12/2015');

END;