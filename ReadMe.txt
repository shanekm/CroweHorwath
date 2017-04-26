Please make sure RestfulService is running prior to running ClientConsoleApp

-Added IoC
-Modify UnityConfig.cs to change "store" ie. SqlStore etc.
-Concrete implementation of FileStore (SqlStore - sample)
-WebAPI uses implementaion of IReader/IWriter - FileStore
-Console app uses IReader - ConsoleStore
-Added Unit tests