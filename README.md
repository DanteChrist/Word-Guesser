# Word Guesser

## **Преглед**

Word Guesser е уеб приложение, създадено за хора, които обичат да упражняват езиковите си умения или да убиват времето си с нещо забавно. Изчислено е, че средното време за един човек да научи език е около 1 година. Нашето приложение ви дава възможност да изследвате нови върхове и да се забавлявате, докато научавате нови думи на различни езици. 

## **Architecture**

Това привожение използва MVC (Model-View-Controller) архитектура който разделя уеб приложението на три основни компонента - Models, Views и Controller. Поставихме нашите данни в папката с данни в подпапка, наречена **Entities**, защото това е конвенция.

(![image](https://github.com/DanteChrist/Word-Guesser/assets/124893931/268dd007-e05d-4299-97af-1311df785462) (![image](https://github.com/DanteChrist/Word-Guesser/assets/124893931/c0a2a17b-d770-4eb5-90aa-138424c70b5b) (![image](https://github.com/DanteChrist/Word-Guesser/assets/124893931/125e9122-50f6-423e-bae6-20a4ea101853)

В следващите екранни снимки можете да видите основните компоненти на нашето уеб приложение:

Папката **Data Folder** ⇒ където се съхраняват обектите, установена е връзката между обектите, прилагат се необходимите миграции и Repositories поставя записи в базата данни, когато таблиците на обекти в базата данни са празни.

Entities: BaseEntity, Language, Picture, Translation,и Word които описват основните секции с данни.

**Controllers папката** ⇒ където се създава бизнес логиката и се случва магията.

Имаме контролер за всяка функция в нашето уеб приложение: GameController, HomeController, LanguagesController, PicturesController, TranslationsController и WordsController.

**Views папката** ⇒ Папката **Views** представлява потребителския интерфейс на приложението.

Във всеки View има файлове, отговорни за показването на точни данни и дизайн за всяка CRUD операция.

## **Функционалност**

**Това уеб приложение включва следните функции:**

- Сменяне на езици
- Разиграване на приложението

## How to Run the Project

### Follow these steps:

1. Клонирайте проекта на вашия локален компютър
2. Отворете папката на проекта с помощта на Visual Studio 2022
3. Направете Build на проекта
4. Стартирайте проекта, като натиснете F5 или щракнете върху зеления бутон "Run" във Visual Studio
