using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle( "Mongo.Entity" )]
[assembly: AssemblyProduct("Mongo.Entity")]
[assembly: AssemblyDescription( "Mongo.Entity handles what needs to be done in order to insert, update, delete or retrieve your entities from MongoDB." )]

[assembly: AssemblyCompany("Carlos J. López")]
[assembly: AssemblyCopyright("Copyright © 2013 Carlos J. López")]
[assembly: AssemblyTrademark("")]

[assembly: AssemblyVersion( "1.0.1.*" )]
// [assembly: AssemblyFileVersion( "1.0.*" )]
[assembly: AssemblyInformationalVersion("1.0.1")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: ComVisible( false )]
[assembly: AssemblyCulture( "" )]

[assembly: Guid( "8d36a24f-32ca-46a2-aeaf-ce5a7123fe76" )]