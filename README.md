# Principles-of-DB
##  Use case: 
Retirement application where an administrator can login and access other user accounts and retiree’s information. Perform CRUD operations on tables and generate report for retiree’s

## SQL Scripts
------------------- -----------------SQL to Create Function to calculate Age ------------------------

CREATE FUNCTION dbo.CalculateAge
(
    @RetireeId INT
)
RETURNS INT
AS
BEGIN
    DECLARE @age INT;
    select @age= DATEDIFF(YEAR, dateofbirth, GETDATE()) from retiree where Retiree_id = @RetireeId    
   
    
    RETURN @age;
END

----------------------Stored Procedure to get Retiree Details -------------------

CREATE PROCEDURE GetRetireeDetails 
    @retireeId Int
AS
BEGIN
declare @retiree_id int = 0;

   
select * from RetireeDetails where retiree_id = @retireeId
select * from address where retiree_id = @retireeId;
select * from beneficiary where retiree_id = @retireeId;
select * from bank where retiree_id = @retireeId;
select * from payment where retiree_id = @retireeId;
select * from Employment where retiree_id = @retireeId;

END

----------------------Stored Procedure to Check for login validation -------------------


CREATE PROCEDURE CheckLogin
    @userid varchar(50),
    @password VARCHAR(50)
AS
BEGIN
    select * from users where userid = @userid and password = @password;
END


--------------Trigger to Create History when Address is deleted---------------------------------

Create TRIGGER tr_address_history
ON dbo.Address
AFTER Delete
AS
BEGIN
  -- Insert a row into another table
  INSERT INTO dbo.Address_History(Address_id,Addressline1, Addressline2, City, State, Zipcode, Retiree_id)
  select Address_id, Addressline1, Addressline2, City, State, Zipcode, Retiree_id from deleted
END

-------------------------------------- View for the Report--------------------------

Create view RetireePay
as
select r.Retiree_id, Firstname, Lastname, SSN, p.Grossamount, p.Netamount, p.Fedtax, p.Statetax, convert(varchar, p.Paymentdate, 107) as Paymentdate
from Retiree r left join payment p on r.Retiree_id = p.Retiree_id

------------SQL to create View using CalculateAge Function-------------------

create view RetireeDetails
as select dbo.calculateage(retiree_id) as age,* from Retiree


## Code
## Login credentials User1/1234
Login page:

![image](https://user-images.githubusercontent.com/78456642/236635142-a0168927-df3d-4f2f-aed0-32339ce32350.png)

Uses check login stored procedure with userid and password as parameters
 dt = s.ExecuteStoredProcedure("CheckLogin", txtUserID.Text, txtPassword.Text);
 

Home page:
Provides option to navigate to Retirees - Manage Users - Reports - Logout

![image](https://user-images.githubusercontent.com/78456642/236635181-e2c48a08-272d-4e39-9571-22b737cd62f5.png)

Retiree Page:

Displays all retirees using view  dt = s.Execute("select * from RetireeDetails"); and and new retiree can be added/updated/deleted

Dashboard Page:

Displays individual retiree details on dashboard page where data is pulled from tables

Manage Users Page:

Where all users are displayed and new user/update/deleted

Report page:

Report is generated using view












