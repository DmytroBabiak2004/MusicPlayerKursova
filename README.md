# 1. Встановлення .NET SDK
# Завантажте та встановіть .NET SDK з офіційного сайту:
# https://dotnet.microsoft.com/download/dotnet

# Перевірте, чи правильно встановлений .NET:
dotnet --version

# 2. Встановлення SQL Server
# Завантажте SQL Server з офіційного сайту:
# https://www.microsoft.com/en-us/sql-server/sql-server-downloads

# Встановіть SQL Server Management Studio (SSMS):
# Завантажте SSMS з офіційного сайту:
# https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms

# 3. Клонування репозиторію
# Клонувати репозиторій:
git clone https://DmytroBabiak2004/Kursova.git

# 4. Налаштування рядка підключення
# Відкрийте файл appsettings.json і змініть рядок підключення до вашої бази даних:
# "ConnectionStrings": {
#   "DefaultConnection": "Server=localhost\\MSSQLSERVER01;Database=YourDatabaseName;Trusted_Connection=True;"
# }

# 5. Встановлення необхідних пакетів Entity Framework
# Встановіть необхідні пакети для Entity Framework:
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

# 6. Створення міграцій
# Створіть міграцію:
dotnet ef migrations add InitialCreate

# 7. Застосування міграцій
# Застосуйте міграції до бази даних:
dotnet ef database update

# 8. Запуск програми
# Запустіть програму:
dotnet run
