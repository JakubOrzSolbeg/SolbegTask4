## DataRepository3

Project dedicated only to storing data using service - repository pattern.

### Usage

Project cannot run on its own. Reference to this project has to be set in main project.

### Configuration

Every project using DataRepository3 have to provide those fields in appsettings:
- ConnectionString[MainDb] - connection string used to connect to local or remove database server 
- MigrationAssembly - name of project using DataRepository3
