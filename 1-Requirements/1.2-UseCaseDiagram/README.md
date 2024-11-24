@startuml
actor "Оператор крана" as Operator
actor "Керівник будівельного майданчика" as Manager
actor "Система моніторингу безпеки" as System

usecase "Моніторинг руху крана" as UC1
usecase "Оповіщення про ризики" as UC2
usecase "Перегляд звітів" as UC3
usecase "Оперативне реагування" as UC4
usecase "Збір даних з датчиків" as UC5
usecase "Генерація сповіщень" as UC6

Operator -- UC1
Operator -- UC2
Manager -- UC3
Manager -- UC4
System -- UC5
System -- UC6

UC2 .> UC1 : extend
UC6 .> UC5 : include
@enduml