alter PROCEDURE login
    @Email nvarchar(64),
    @Password nvarchar(20)
as
BEGIN
    if exists (

    select *
    from [user]
    where email = @Email and [password] = @Password
    ) 
    begin
        return 200;
    end
     else
     BEGIN
        return 404;
    END
end;

exec login @Email = 'nguyenvannhv26@gmail.com', @Password = '123456';