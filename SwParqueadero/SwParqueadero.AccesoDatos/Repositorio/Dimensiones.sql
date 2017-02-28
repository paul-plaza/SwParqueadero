USE [DbParqueo]
GO

INSERT INTO [dbo].[TBL_DIMENSION] VALUES (1,'GRANDE',3,2)
INSERT INTO [dbo].[TBL_DIMENSION] VALUES (2,'MEDIANO',2,2)
INSERT INTO [dbo].[TBL_DIMENSION] VALUES (3,'PEQUEÑO',1,2)

--Insert empresa
INSERT INTO TBL_EMPRESA
     VALUES
           (1
           ,'UNIVERSIDAD TECNOLÓGICA ISRAEL'
           ,'bsdevelopers4@gmail.com'
           ,'smtp.gmail.com'
           ,587
           ,'paul123plaza')
GO