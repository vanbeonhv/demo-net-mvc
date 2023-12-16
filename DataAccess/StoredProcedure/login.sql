alter PROCEDURE login
    @Email nvarchar(64),
    @Password nvarchar(20)
as
BEGIN
    if exists (

    select *
    from [user]
    where email = @Email and [password] = @Password
    ) return 200; else return 404
end;

exec login @Email = 'nguyenvannhv26@gmail.com', @Password = '123456';