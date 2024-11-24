# Перелік шаблонів проектування
У моєму програмному продукті в частині, що реалізує додаток, були реалізовані наступні шаблони проектування: **Команда**, **Посередник**, **Спостерігач**, **MVVM (Model-View-ViewModel)**.

У рамках лаборатоної роботи буде розглядатись реалізація шаблону **Посередник**
# Специфікація класів
![diagram](../images/5%20ClassDiagram.png)
## Class: RelayCommand
### Опис:
Реалізація паттерну **Команда**, що дозволяє інкапсулювати дію, яка буде виконана за допомогою команд в інтерфейсі користувача.

### Властивості:
- `Action<object?> execute`: Делегат, який визначає виконувану дію.
- `Func<object?, bool> canExecute`: Делегат, що визначає, чи можна виконати команду (опціонально).

### Методи:
- `RelayCommand(Action<object?> execute, Func<object?, bool> canExecute = null)`: Конструктор класу, ініціалізує команду, задаючи виконувану дію і опціональний делегат для перевірки можливості виконання.
- `bool CanExecute(object? parameter)`: Перевіряє, чи можна виконати команду.
- `void Execute(object? parameter)`: Виконує команду.
- `event EventHandler? CanExecuteChanged`: Подія, що сповіщає про зміни, які можуть вплинути на можливість виконання команди.

---

## Class: BaseViewModel
### Опис:
Базовий клас для всіх **ViewModel**, що підтримує реалізацію інтерфейсу `INotifyPropertyChanged` для сповіщення змін властивостей.

### Властивості:
- `event PropertyChangedEventHandler? PropertyChanged`: Подія, що сповіщає про зміни властивостей.

### Методи:
- `void OnPropertyChanged([CallerMemberName] string propertyName = "")`: Викликає подію `PropertyChanged`.

---

## Class: AuthorizationViewModel
### Опис:
Клас, що відповідає за логіку авторизації користувача. 

### Властивості:
- `RelayCommand AuthorizationCommand`: Команда для виконання авторизації.
- `RelayCommand ChangePasswordCommand`: Команда для зміни паролю.

### Методи:
- `AuthorizationViewModel(MenuMediatorService menuMediator)`: Конструктор, який ініціалізує команди та інкапсулює логіку авторизації.
- `void Authorization(object? obj)`: Метод для авторизації.
- `void ChangePassword(object? obj)`: Метод для зміни паролю.
- `void GoToMonitoringMenu()`: Перехід до меню моніторингу.

---

## Class: MonitoringViewModel
### Опис:
Клас для меню моніторингу, де відображається моніторинг та можливість переходу до звітів.

### Властивості:
- `RelayCommand GoToReportsMenuCommand`: Команда для переходу до меню звітів.

### Методи:
- `MonitoringViewModel(MenuMediatorService menuMediator)`: Конструктор для ініціалізації команди.
- `void GoToReportsMenu(object? obj)`: Перехід до меню звітів.

---

## Class: ReportsViewModel
### Опис:
Клас для меню звітів, де відображаються звіти і є можливість повернення до моніторингу.

### Властивості:
- `RelayCommand GoToMonitoringMenuCommand`: Команда для переходу до меню моніторингу.

### Методи:
- `ReportsViewModel(MenuMediatorService menuMediator)`: Конструктор для ініціалізації команди.
- `void GoToMonitoringMenu(object? obj)`: Перехід до меню моніторингу.

---

## Class: MenuMediatorService
### Опис:
Посередник між різними `ViewModel`, який управляє зміною поточного вибраного меню.

### Властивості:
- `AuthorizationViewModel? _authorizationMenu`: Меню авторизації.
- `MonitoringViewModel? _monitoringMenu`: Меню моніторингу.
- `ReportsViewModel? _reportsViewModel`: Меню звітів.
- `BaseViewModel? _selectedMenu`: Поточне вибране меню.

### Методи:
- `MenuMediatorService()`: Конструктор, ініціалізує сервіси меню.
- `void SetMenus(AuthorizationViewModel, MonitoringViewModel, ReportsViewModel)`: Встановлює конкретні меню.
- `void GoToAuthentacationMenu()`: Перехід до меню авторизації.
- `void GoToMonitoringMenu()`: Перехід до меню моніторингу.
- `void GoToReportsMenu()`: Перехід до меню звітів.
- `event PropertyChangedEventHandler? PropertyChanged`: Подія для сповіщення про зміни вибраного меню.

# Опис реалізації шаблону
Паттерн "Посередник" реалізовано через клас **MenuMediatorService**, який виступає посередником між різними ViewModel класами (**AuthorizationViewModel**, **MonitoringViewModel**, **ReportsViewModel**). Він керує зміною відображуваного меню, повідомляючи **MainViewModel** про необхідність відобразити інше меню.

# Обґрунтування вибору шаблону
Шаблон проектування "Посередник" був обраний для цього додатку через його здатність централізувати логіку взаємодії між різними частинами інтерфейсу користувача, знизити рівень залежностей між компонентами, спростити підтримку програми, а також забезпечити гнучкість при внесенні змін у навігацію між екранними формами або функціональними модулями. Це дозволяє підтримувати програму чистою, зрозумілою та легкою для масштабування.