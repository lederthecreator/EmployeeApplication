# EmployeeApplication

## Запросы к БД
Выборка всех сотрудников, у кого ЗП выше 10000
```
select * from employee where salary > 10000;
```

Удаление сотрудников, старше 70 лет
```
delete
from employees
where date_part('year', current_date) - date_part('year', employees.birth_day) > 70;
```

Обновить ЗП до 15000 тем сотрудникам, у которых она меньше
```
update employees
set salary = 15000
where salary < 15000;
```
