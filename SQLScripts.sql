
------------------- SQL to Create Function ------------------------

/*

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


------------SQL to create View-------------------
create view RetireeDetails
as select dbo.calculateage(retiree_id) as age,* from Retiree


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




CREATE PROCEDURE CheckLogin
    @userid varchar(50),
    @password VARCHAR(50)
AS
BEGIN
    select * from users where userid = @userid and password = @password;
END


--------------Adress History Table-------------------------------



CREATE TABLE [dbo].[Address_History](
	[Address_History_id] [int] IDENTITY(1,1) NOT NULL,
	[Address_id] [int] NOT NULL,
	[Addressline1] [varchar](100) NOT NULL,
	[Addressline2] [varchar](100) NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](100) NOT NULL,
	[Retiree_id] [int] NULL,
	[zipcode] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Address_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

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

---------------------------------------------------

Create view [dbo].[RetireePayView]
as
  select r.Retiree_id, Firstname,Lastname,SSN,p.Paymentdate,p.GrossAmount,p.NetAmount,p.FedTax,p.StateTax
from Retiree r inner join 
(select Retiree_id,year(Paymentdate) as Paymentdate,sum(Grossamount)as GrossAmount,sum(Netamount) as NetAmount,sum(Fedtax) as FedTax,sum(Statetax) as StateTax from Payment
group by Retiree_id,YEAR(Paymentdate)) as p on r.Retiree_id = p.Retiree_id

GO

*/