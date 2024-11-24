@startuml
skinparam rectangle {
  BackgroundColor #EFEFEF
  BorderColor #333
  BorderThickness 2
  RoundCorner 15
}

rectangle "Головне меню" {
    rectangle "Авторизація" as auth {
        rectangle "Вхід" as login
        rectangle "Відновлення паролю" as password_recovery
    }
    rectangle "Моніторинг" as monitoring {
        rectangle "Дані крана" as crane_data
        rectangle "Аномалії" as anomalies
    }
    rectangle "Звіти" as reports {
        rectangle "Список звітів" as report_list
        rectangle "Експорт звіту" as export_report
    }
}

auth --> monitoring : Після авторизації
monitoring --> reports : Доступ до звітів
reports --> monitoring : Повернення до моніторингу
@enduml