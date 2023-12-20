# YDB via Postgres driver for .NET

## How to use

run `docker-compose up` and open browser via http://localhost:80

## Expected result

 `{"scalar" : 1}`

# Real result

Exception 
```csharp
ydbposgresqlexample-web-1  | System.Net.Sockets.SocketException (00000001, 11): Resource temporarily unavailable
ydbposgresqlexample-web-1  |    at System.Net.Dns.GetHostEntryOrAddressesCore(String hostName, Boolean justAddresses, AddressFamily addressFamily, Int64 startingTimestamp)
ydbposgresqlexample-web-1  |    at System.Net.Dns.<>c.<GetHostEntryOrAddressesCoreAsync>b__33_0(Object s, Int64 startingTimestamp)
ydbposgresqlexample-web-1  |    at System.Net.Dns.<>c__DisplayClass39_0`1.<RunAsync>b__0(Task <p0>, Object <p1>)
ydbposgresqlexample-web-1  |    at System.Threading.Tasks.ContinuationResultTaskFromTask`1.InnerInvoke()
ydbposgresqlexample-web-1  |    at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
ydbposgresqlexample-web-1  | --- End of stack trace from previous location ---
ydbposgresqlexample-web-1  |    at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
ydbposgresqlexample-web-1  |    at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot, Thread threadPoolThread)
ydbposgresqlexample-web-1  | --- End of stack trace from previous location ---
ydbposgresqlexample-web-1  |    at Npgsql.TaskTimeoutAndCancellation.ExecuteAsync(Func`2 getTaskFunc, NpgsqlTimeout timeout, CancellationToken cancellationToken)
ydbposgresqlexample-web-1  |    at Npgsql.TaskTimeoutAndCancellation.ExecuteAsync[TResult](Func`2 getTaskFunc, NpgsqlTimeout timeout, CancellationToken cancellationToken)
ydbposgresqlexample-web-1  |    at Npgsql.Internal.NpgsqlConnector.ConnectAsync(NpgsqlTimeout timeout, CancellationToken cancellationToken)
ydbposgresqlexample-web-1  |    at Npgsql.Internal.NpgsqlConnector.RawOpen(SslMode sslMode, NpgsqlTimeout timeout, Boolean async, CancellationToken cancellationToken, Boolean isFirstAttempt)
ydbposgresqlexample-web-1  |    at Npgsql.Internal.NpgsqlConnector.<Open>g__OpenCore|216_1(NpgsqlConnector conn, SslMode sslMode, NpgsqlTimeout timeout, Boolean async, CancellationToken cancellationToken, Boolean isFirstAttempt)
ydbposgresqlexample-web-1  |    at Npgsql.Internal.NpgsqlConnector.Open(NpgsqlTimeout timeout, Boolean async, CancellationToken cancellationToken)
ydbposgresqlexample-web-1  |    at Npgsql.PoolingDataSource.OpenNewConnector(NpgsqlConnection conn, NpgsqlTimeout timeout, Boolean async, CancellationToken cancellationToken)
ydbposgresqlexample-web-1  |    at Npgsql.PoolingDataSource.<Get>g__RentAsync|28_0(NpgsqlConnection conn, NpgsqlTimeout timeout, Boolean async, CancellationToken cancellationToken)
ydbposgresqlexample-web-1  |    at Npgsql.NpgsqlConnection.<Open>g__OpenAsync|45_0(Boolean async, CancellationToken cancellationToken)
ydbposgresqlexample-web-1  |    at Npgsql.NpgsqlDataSource.OpenConnectionAsync(CancellationToken cancellationToken)
ydbposgresqlexample-web-1  |    at Npgsql.NpgsqlDataSource.OpenConnectionAsync(CancellationToken cancellationToken)
ydbposgresqlexample-web-1  |    at Program.<>c__DisplayClass0_0.<<<Main>$>b__1>d.MoveNext() in /src/Ydb.Posgresql.Example/Program.cs:line 29
```