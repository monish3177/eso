create table [Masters].[DashboardMessages](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	Messagetext varchar(1000),
	Insertdatetime datetime,
	Types char(1),
	visible char(1)
)
insert into [Masters].[DashboardMessages] values(' <img src="http://mpsc.mp.nic.in/gacdn/SchOri/images/new.gif" width="30" height="15" /> Management quota student are not eligible for this portal',GETDATE(),'N','S')
insert into [Masters].[DashboardMessages] values('Portal is on for academic year 2018 - 19',GETDATE(),'O','S')


Go
create Procedure [Masters].[DashboardMessages_SP]

AS
BEGIN

Select  Messagetext
 from [Masters].[DashboardMessages] where visible ='S'
END
