select DM_File_Version.*   , KEY_TBL.*
From  FREETEXTTABLE (DM_FT, (file_stream), 'STUHL') AS KEY_TBL 
INNER JOIN DM_FT AS DM_FT_1 ON DM_FT_1.path_locator =  KEY_TBL.[KEY]
INNER JOIN dbo.DM_File_Version  ON DFV_path_locator_string = KEY_TBL.[KEY]