DECLARE @Schema            VARCHAR(100)
      , @ObjectName        VARCHAR(100)
      , @ObjectType        VARCHAR(100)
      , @ParameterID       INT
      , @ParameterName     VARCHAR(100)
      , @ParameterDataType VARCHAR(100)
      , @ParameterMaxBytes INT
      , @IsOutPutParameter SMALLINT
      , @strOutput         varchar(3000)
	  , @strOutputtext	   varchar(max)
	  , @strProc		   varchar(10) = 'upADD'

SELECT @strOutputtext = REPLACE(' SqlCommand cmd = new SqlCommand("[PROC]", conn);
cmd.CommandType = CommandType.StoredProcedure;
			' , '[PROC]' , @strProc )

DECLARE DataCursor CURSOR FAST_FORWARD
FOR SELECT SCHEMA_NAME(SCHEMA_ID) AS [Schema], SO.name AS ObjectName, SO.Type_Desc AS [ObjectType (UDF/SP)], P.parameter_id AS ParameterID, P.name AS ParameterName, TYPE_NAME(P.user_type_id) AS ParameterDataType, P.max_length AS ParameterMaxBytes, P.is_output AS IsOutPutParameter
      FROM sys.objects AS SO
      INNER JOIN sys.parameters AS P ON SO.OBJECT_ID = P.OBJECT_ID
     WHERE SO.OBJECT_ID IN
                          (SELECT OBJECT_ID
                             FROM sys.objects
                            WHERE TYPE IN('P', 'FN')
                                                    )
      AND SO.name = @strProc
    ORDER BY [Schema], SO.name, P.parameter_id;

OPEN DataCursor

FETCH NEXT FROM DataCursor INTO @Schema
                              , @ObjectName
                              , @ObjectType
                              , @ParameterID
                              , @ParameterName
                              , @ParameterDataType
                              , @ParameterMaxBytes
                              , @IsOutPutParameter

WHILE @@FETCH_STATUS = 0
BEGIN

  If @IsOutPutParameter <> 0 
  BEGIN
    SELECT @strOutput  = 'SqlParameter vendor = cmd.Parameters.Add("[NAME]", SqlDbType.[TYPE] [LENGHT]);
	vendor.Direction = ParameterDirection.Output;
	'
    SELECT @strOutput  = REPLACE ( @strOutput , '[NAME]' , @ParameterName )
    SELECT @strOutput  = REPLACE ( @strOutput , '[TYPE]' , @ParameterDataType )
	if @ParameterDataType = 'varchar' or @ParameterDataType = 'nvarchar'  or @ParameterDataType = 'text' or @ParameterDataType = 'ntext'
	BEGIN
		SELECT @strOutput  = REPLACE ( @strOutput , '[LENGHT]' , ' , ' + convert( varchar, @ParameterMaxBytes ))
	END
	ELSE
	BEGIN
		SELECT @strOutput  = REPLACE ( @strOutput , '[LENGHT]' , '' )
	END
  END
  ELSE
  BEGIN
    SELECT @strOutput  = 'SqlParameter [NAME] = cmd.Parameters.Add("@[NAME]", SqlDbType.[TYPE] [LENGHT]);
	[NAME].Direction = ParameterDirection.Input;
	[NAME].Value = [NAME];
			   '
    SELECT @strOutput  = REPLACE ( @strOutput , '[NAME]' , REPLACE( @ParameterName , '@', '') )
    SELECT @strOutput  = REPLACE ( @strOutput , '[TYPE]' , @ParameterDataType )
	if @ParameterDataType = 'varchar' or @ParameterDataType = 'nvarchar'  or @ParameterDataType = 'text' or @ParameterDataType = 'ntext'
	BEGIN
		SELECT @strOutput  = REPLACE ( @strOutput , '[LENGHT]' ,  ' , '  + convert( varchar, @ParameterMaxBytes ))
	END
	ELSE
	BEGIN
		SELECT @strOutput  = REPLACE ( @strOutput , '[LENGHT]' , '' )
	END
  END

  SELECT @strOutputtext = @strOutputtext + '  
  ' + @strOutput


  FETCH NEXT FROM DataCursor INTO @Schema
                                , @ObjectName
                                , @ObjectType
                                , @ParameterID
                                , @ParameterName
                                , @ParameterDataType
                                , @ParameterMaxBytes
                                , @IsOutPutParameter
END

CLOSE DataCursor

DEALLOCATE DataCursor


 PRINT @strOutputtext