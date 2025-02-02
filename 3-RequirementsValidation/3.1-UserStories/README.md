## Користувацькі історії

### US1.1: Авторизація через електронну пошту та пароль
**Критерії приймального тестування (AC1.1):**
```gherkin
  Scenario: Успішний вхід користувача з правильними обліковими даними
    Given користувач знаходиться на сторінці авторизації
    When користувач вводить правильну електронну пошту і пароль
    And натискає кнопку "Увійти"
    Then користувач потрапляє на головну сторінку системи

  Scenario: Помилка при неправильному паролі
    Given користувач знаходиться на сторінці авторизації
    When користувач вводить правильну електронну пошту, але неправильний пароль
    And натискає кнопку "Увійти"
    Then користувач бачить повідомлення "Невірний пароль"
```

### US1.2: Відновлення паролю
**Критерії приймального тестування (AC1.2):**
```gherkin
  Scenario: Успішне відновлення паролю
    Given користувач знаходиться на сторінці відновлення паролю
    When користувач вводить свою електронну пошту
    And натискає "Надіслати"
    Then користувач отримує лист з посиланням для скидання паролю
```

### US2.1: Відображення даних у реальному часі
**Критерії приймального тестування (AC2.1):**
```gherkin
  Scenario: Дані оновлюються кожні 0.5 секунди
    Given оператор знаходиться на сторінці моніторингу
    When кран змінює швидкість або нахил
    Then система оновлює відповідні показники на екрані у реальному часі
```

### US3.1: Сповіщення про перевищення швидкості
**Критерії приймального тестування (AC3.1):**
```gherkin
  Scenario: Перевищення швидкості крана
    Given швидкість крана перевищує встановлену межу
    When система виявляє перевищення
    Then система надсилає сповіщення оператору та керівнику
```

### US3.2: Сповіщення про наближення до небезпечної зони
**Критерії приймального тестування (AC3.2):**
```gherkin
  Scenario: Кран наближається до небезпечної зони
    Given система фіксує місцезнаходження крана
    When кран підходить до небезпечної зони
    Then система генерує сповіщення для оператора
```

### US4.1: Експорт звіту у форматі PDF
**Критерії приймального тестування (AC4.1):**
```gherkin
  Scenario: Автоматичне архівування звітів
    Given новий звіт створено
    When завершується поточна робоча зміна
    Then звіт автоматично додається до архіву системи
```

### US4.2: Архівування звітів
**Критерії приймального тестування (AC4.2):**
```gherkin
  Scenario: Автоматичне архівування звітів
    Given новий звіт створено
    When завершується поточна робоча зміна
    Then звіт автоматично додається до архіву системи
```

### US5.1: Генерація звіту у форматі CSV
**Критерії приймального тестування (AC5.1):**
```gherkin
  Scenario: Збереження звіту у форматі CSV
    Given користувач відкрив звіт про аварійну ситуацію
    When натискає кнопку "Експорт у CSV"
    Then звіт зберігається на пристрій у форматі CSV
```

### US6.1: Гарантована доступність 99.9% часу
**Критерії приймального тестування (AC6.1):**
```gherkin
  Scenario: Тестування доступності системи
    Given система працює у нормальному режимі
    When виконується тест на доступність протягом місяця
    Then час доступності не менший за 99.9%
```