-- replace YOURTABLE 
-- uses dynamic sql to get a before and after per column


CREATE trigger YOURTABLE_Audit_Tr on [dbo].[YOURTABLE]
after UPDATE
as
BEGIN
    set nocount on;
        create table #updatedCols (Id int identity(1, 1), updateCol nvarchar(128))

        --find all columns that were updated and write them to temp table
        insert into #updatedCols (updateCol)
        select
            column_name
        from
            information_schema.columns
        where   
            table_name = 'YOURTABLE'
            
        --temp tables are used because inserted and deleted tables are not available in dynamic SQL
        select * into #tempInserted from inserted
        select * into #tempDeleted from deleted

        declare @cnt int = 1
        declare @rowCnt int
        declare @columnName nvarchar(128)
        declare @sql nvarchar(4000)

        select @rowCnt = count(*) from #updatedCols

        --execute insert statement for each updated column
        while @cnt <= @rowCnt
        BEGIN
            select @columnName = updateCol from #updatedCols where id = @cnt

            set @sql = N'
                insert into [YOURTABLE_Audit] ([YOURTABLEId], [EventDate], [ColumnName], [OriginalValue], [NewValue])
                select
                     i.Id, GetUTCDate(), ''' + @columnName + ''', d.' + @columnName + ', i.' + @columnName +'
                from
                    #tempInserted i
                    join #tempDeleted d on i.Id = d.Id and isnull(Cast(i.' + @columnName + ' as varchar(4000)), '''') <> isnull(Cast(d.' +@columnName + ' as varchar(4000)), '''')
                '
            exec sp_executesql @sql
            set @cnt = @cnt + 1
        END
END
