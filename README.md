# Service for storing schedules
Данный веб-сервис разработан на ASP.NET Core Web API и обеспечивает взаимодействие с базой данных MS SQL Server для выполнения CRUD операций с использованием HTTP запросов. API предназначен для хранения данных, необходимых для составления расписания.
Для работы были использованы следующие библиотеки и фреймворки:
- AutoMapper: для упрощения процесса маппинга между сущностями базы данных и DTO объектами.
- Microsoft.EntityFrameworkCore: для работы с базой данных.
- Microsoft.EntityFrameworkCore.SqlServer: предоставляет поддержку для работы с MS SQL Server.
- Microsoft.EntityFrameworkCore.Tools: для использования инструментов Entity Framework Core, таких как миграции и т.д.

CRUD операции, поддерживаемые веб-сервисом:
- GET: Получение данных (например, список всех записей или конкретной записи по идентификатору).
- POST: Создание новой записи.
- PUT: Обновление существующей записи.
- DELETE: Удаление записи по идентификатору.

**Особенности API:**
- При попытке удаления элемента API проверяет, связан ли данный элемент с другими таблицами.
- Если элемент уже используется в другой таблице, API возвращает ошибку и не позволяет удалить запись, чтобы избежать нарушения целостности данных.

Таким образом, этот RESTful API обеспечивает безопасное взаимодействие с данными, предотвращая нецелевые действия при попытке удаления элементов, которые имеют зависимости в других таблицах.

[Другая ветка](https://github.com/FredNekrasov/service_for_storing_schedules/tree/ForMobile) может выполнять только GET запросы для передачи данных мобильному клиенту и при этом имеет схожую структуру.