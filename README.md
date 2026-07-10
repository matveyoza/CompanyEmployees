1. **Восстановите пакеты и зависимости**
   Откройте терминал в корневой папке проекта и выполните:
   ```bash
   dotnet restore
   Обновите базу данных
Примените миграции Entity Framework, чтобы создать или обновить локальную базу данных LocalDB:

Bash
dotnet ef database update
(Если у вас не установлены инструменты EF CLI, используйте Update-Database в Консоли диспетчера пакетов Visual Studio).

Запустите приложение через Kestrel
Запустите проект напрямую без IIS:

Bash
dotnet run --project CompanyEmployees
После этого API будет доступно по адресу: http://localhost:5257/api/companies
