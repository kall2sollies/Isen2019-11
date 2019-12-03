# Prérequis

* Installer Visual Studio Code
* Installer .net Core SDK 3.0.100 :
  https://dotnet.microsoft.com/download
  et tester avec `dotnet --version`  
* Installer un terminal 'sérieux' (Terminus, cmder...)
* Installer `git` et tester avec `git --version` 
* Dossier de travail : `Isen.Dotnet`  
* Ouvrir ce dossier depuis un terminal : cd (...) puis `code .`  
* Créer `README.md` (ce fichier)

# Préparation de la solution

## En faire un repository git
* `git init` afin d'initialiser le dossier comme repo git
* Créer un fichier `.gitignore`  avec `touch .gitignore`  
* Prendre sur internet un modèle de .gitignore
  adapté à c# / .net

## Créer un remote et push le projet
* Sur Github / GitLab (ou autre), créer un repo remote pour ce projet.  
* Ajouter ce remote comme upstream du repo local :
`git remote add origin https://github.com/kall2sollies/Isen2019-11`  
* commit initial du projet :
  `git add .`  
  `git commit -m "initial commit"`  
  `git push origin master`  

## Créer un premier projet (console)
  * Dans le dossier de travail, créer un dossier `src/Isen.Dotnet.ConsoleApp`.
  * Naviguer dans ce dossier dans le terminal. 
  * Créer un projet console en utilisant la `CLI` dotnet  (Command Line Interface) avec la commande :
  `dotnet new console`  
  * tester avec `dotnet run` 

## Architecture d'une solution (workspace) donet
* `Isen.Dotnet` est le nom de la solution (workspace) et  en même temps la racine de tous les namespace.
* `Isen.Dotnet.ConsoleApp` est un **projet**.  Son nom correspond au `namespace` du projet, lui-même étant hiérarchiquement imbriqué au namespace de la solution.
* Le fichier projet a l'extension `.csproj`. C'est un fichier xml qui décrit :
  * Le type de projet
  * Ses dépendances
  * Le runtime utilisé
* Le workspace / solution dispose d'un fichier de solution, qui recence tous les projets de la solution, ainsi que les fichiers annexes (type readme, gitignore...). Ce fichier est de type `.sln` et va être créé ainsi :

Depuis le dossier racine (Isen.Dotnet)
`dotnet new sln`  (Ceci crée simplement le fichier sln)  
`dotnet sln add src\Isen.Dotnet.ConsoleApp\` (Ceci ajoute le projet console au référentiel que constitue le sln).

## Création du projet Library

* Sous src/ créer un dossier `Isen.Dotnet.Library` et naviguer dedans avec le terminal.  
* Lancer la commande `dotnet new classlib`  
* Supprimer `Class1.cs`  
* Revenir à la racine du projet, et référencer ce nouveau projet dans le sln :
  `dotnet sln add src\Isen.Dotnet.Library\`  
* Ajouter ce projet (library) comme référence du projet console. De cette manière, le projet console pourra utiliser des classes codées dans le projet Libray. Depuis le dossier src/Isen.Dotnet.ConsoleApp, lancer :
  `dotnet add reference ..\Isen.Dotnet.Library\`  

## Vérifications
La hiérarchie est :
* Isen.DotNet/ (sln)
  * src/
    * Isen.DotNet.ConsoleApp/ (csproj)
    * Isen.DotNet.Library/ (csproj)
  * README.md

  Le fichier sln doit contenir des références aux 2 projets (ConsoleApp et Library).  

  Le fichier src/Isen.DotNet.ConsoleApp/Isen.DotNet.ConsoleApp.csproj doit contenir une référence à Library.

# Le C#

## Créer une classe Hello
Dans le projet Library, créer Hello.cs. :
* using, namespace, class
* Propriété avec accesseur implicite
* Constructeur
* Méthode Greet()

Dans le projet console, instancier la classe Hello (il faut un using) et envoyer la sortie de la méthode Greet vers la console.  

## Création d'une classe de Liste
Dans Library, créer MyCollection.cs et ajouter les déclarations d'une classe C#. (on peut dupliquer Hello).

Le but de cette classe est de créer et manipuler une liste de string (ajout, suppression, etc...).  
On va utiliser un tableau natif (`string []`) comme structure de stockage interne de la liste.  

### Base de la classe
* Ajouter un tableau natif privé, pour le stockage de la liste.
* Constructeurs :
  * Initialisation du tableau
  * Surcharge avec tableau en paramètre
* Affichage : override de ToString, construction d'une chaine avec tous les éléments en utilisant `StringBuilder`
* Tester cet état de la classe dans le projet console.

### Méthode Add(item)
Cette méthode ajoute un élément passé en argument à la fin de la liste.  
Coder cette méthode. La tester.

### Méthode RemoveAt(index)
Cette méthode retire l'élément situé à l'index passé en argument. Index 0-based.  
Coder cette méthode. La tester.

### Méthode IndexOf(item)
Cette méthode renvoie l'index 0-based de l'élément passé en argument (ou le premier, si l'élément y est plusieurs fois).  
Coder cette méthode. La tester.  

### Accesseur / indexeur
Coder l'accesseur qui va permettre d'accéder au valeur de la liste comme si c'était un tableau primitif :
`myCollection[3]`  
Réécrire dans les autres méthodes tous les appels `_values[i]` qui deviennent `this[i]`.  

### Ajout d'un projet de tests unitaires

* Créer un dossier `tests/` au niveau de `src/` (donc à la racine) 
* Dans ce dossier, créer `Isen.Dotnet.UnitTests/` et naviguer dedans avec le terminal.
* Créer le projet de tests avec `dotnet new xunit`
* Référencer Library dans le projet de tests : 
  `dotnet add reference ../../src/Isen.Dotnet.Library`
* Ajouter le projet de tests au fichier sln : depuis la racine du projet : `dotnet sln add tests/Isen.Dotnet.UnitTests/`
* Renommer la classe `UnitTest1` en `MyLibraryStringTests`
* Ecrire 2 tests bidon (un qui réussit, un qui plante)
* Lancer les tests, depuis le répertoire du projet de tests, avec `dotnet test`  

### Ajout de méthodes de tests unitaires

* Créer 2 méthodes statiques pour générer un tableau primitif de référence, et une liste créée à partir de ce tableau.
* Tester `Count()` en vérifiant que les 2 dimensions sont les mêmes (`Assert.Equal()`).
* Dans la classe MyCollection, ajouter un getter pour rendre Values visible.
* Tester `Add()` en utilisant le `Assert.Equal(array, array)`  
* Tester 'IndexOf()` au début, au milieu, à la fin
* Tester l'accesseur indexeur `this[index]` au début, au milieu, à la fin.
* Tester `RemoveAt()` en comparant les états successifs de la liste avec des arrays statiques qui representent les états attendus.

### Méthode Remove(item)
Cette méthode prend un item en paramètre, et retire cet élément de la liste si elle le trouve. S'il y en plusieurs, elle retire le premier. S'il n'y en a pas, elle ne fait rien.
La méthode renvoie un bool selon qu'elle a retiré ou non l'élément.
Coder ceci en TDD = Test Driven Development (Prototype, test, implémentation).

### Méthode Insert(index, item)
Cette méthode insère l'item à l'index donné, et décale les éléments suivants.  
Ex : `"A", "B", "D"` => `Insert(2, "C")` => `"A", "B", "C", "D"`.  

### Méthode Clear()
Cette méthode vide la liste.  

### Ajouter le support de l'énumération via l'interface `IList<string>`
* Implémenter l'interface `IList<string>` et coder les méthodes manquantes requises.  

## Généralisation de la classe MyCollection

### Conversion générique
Toute la classe `MyCollection` a été codée comme une liste mutable de `string`.
Cependant, rien, à part les références aux types `string`, n'oblige cette classe à se limiter à `string`.
* Dans la déclation de la classe, remplacer `MyCollection` par `MyCollection<T>`, où sera un type générique, résolu lors de l'instanciation.
* Dans les tests, remplacer les instiaciations `new MyCollection()` par `new MyCollection<string>()`.
* Dans le code de la classe, remplacer tous les `string` qui conservent au type de la liste, par le type générique `T`.

### Dupliquer les tests pour tester une liste d'entiers
* Dupliquer la classe de test, sans ses méthodes, en l'appelant `MyCollectionIntTests`
* Récupérer les listes de reférences et les convertir en liste d'int
* Reprendre les méthodes de test les unes après les autres.

# Création d'un projet ASP.Net Core MVC

## Terminologie
* **ASP** = Active Server Page. Equivalent Microsoft de PHP, antérieur aux années 2000. HTML + templating / code en Visual Basic. 
* **.Net** : Framework et machine virtuelle (runtime) utilisant C# (ou VB.Net) comme langage de programmation, et un ensemble d'API (librairies) qui constituent le framework .Net. Version actuelle : Framework .Net 4.7 (dit classic)
* **.Net Core** : reboot Open Source et multiplate-forme du Framework .Net, basé sur Mono. Version actuelle : .Net Core 3.0
* **C#** : langage de programmation objet, statique, fortement typé, similaire à Java, et utilisant les API de .Net. Version actuelle : 8.0. Le compilateur .Net Core (multiplateforme) s'appelle *Roslyn*.
* **MVC** (Model View Controller) : transposition du design-pattern MVC dans un environnement Web.
  * *Model* : asbtraction de l'accès aux données, sur base SQL Server, MySQL, SQLite, etc...
  * *View* : fichiers .cshtml (comme html + C#). Il s'agit de fichiers de syntaxe html, et utilisant le moteur Razor (C#) comme langage de templating.
  * *Controller* : classes C# ayant une convention de nommage pour donner leurs noms aux vues et contrôleurs, et intégrant les données issues du modèle soit directement, soit au travers de design-patterns type 'Repository'.

## Accès aux données
Problématique en web :
* Accès aux données d'une base
* Systématiser les opérations courantes (CRUD = Create Read Update Delete)
* Lier un modèle objet (code) avec un schéma (schéma de base de données)

Afin de systématiser ces opérations, et de les rendre runtime-safe (vérification, compilation, maintenabilité), sont apparus les framework **ORM** (Object Relational Mapping). Les classes de modèle sont générées par un outil (ou au moins, le mapping avec la base de données est défini dans un fichier de configuration).

Le framework ORM le + utilisé en ASP.Net est **Entity Framework (Core)**. Il existe aussi NHibernate, issu de Hibernate (Java), et d'autres...

## Ajout d'un projet ASP.NET Core MVC
* Créer le dossier du projet : `src/Isen.Dotnet.Web`
* En ligne de commande, naviguer vers ce dossier, et utiliser la CLI .Net avec la commande :   
`dotnet new mvc`
* Ajouter le projet de library comme référence à ce projet :  
 `dotnet add reference ..\Isen.Dotnet.Library\`
* Ajouter ce projet à la solution (fichier .sln) :  
  `dotnet sln add src\Isen.Dotnet.Web\`
* Commit
* Tester l'exécution : naviguer vers le dossier `src\Isen.Dotnet.Web\`, puis :
  `dotnet run` puis https://localhost:5001 ou http://localhost:5000

## Anatomie des fichiers générés

### Fichiers et dossiers Web

* Dossier `wwwroot/` :
  * contient les 'assets' web, à savoir les fichiers `javascript`, `css`, images, font... Bref, toutes les ressources web.  
  * Les librairies web externes (type Bootsrap, JQuery, Angular, Vue JS, React...) se trouveront aussi dans ce dossier.
  * Il est tout à fait possible de combiner la CLI `dotnet` avec une autre CLI de gestion de projet web, telle que `npm`, la CLI Angular, etc...
  * De même, il est tout à fait possible de produire le javascript par compilation de code `TypeScript`, et d'intégrer les procédures de compilation TS au build du projet.
  * Tout pareil pour `CSS` avec `SASS` (ou `LESS`), leurs compilateurs peuvent être intégrés au build du projet.
* Dossier `Views/`
  * Chaque sous-dossier (à part Shared) correspond à UN contrôleur. Home est donc un `controller`.  
  * Dans le dossier d'un contrôleur, chaque fichier .cshtml correspond à une `action`. On peut dire qu'une action est une **vue**, avec une url particulière. 
  Les fichiers cshtml contiennent principalement du HTML (et quelques directives de templating en syntaxe Razor). Exemple d'insertion d'une variable C# / Razor dans le code HTML :
````
@{
    var welcomeMessage = $"Bienvenue, il est {DateTime.Now.ToShortTimeString()}";
    ViewData["Title"] = "Home Page";
}
<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>@welcomeMessage</p>
</div>
````
  * Le schéma des url, à ce stade, semble être `/Controller/Action` `/Controller/Vue`
  * Les fichiers de vue `Index.cshtml` et `Privacy.cshtml` contiennent le contenu des pages correspondantes, mais PAS le header (menu) ni le footer.
  * Le dossier `Shared/` est un dossier réservé, et contient notamment le fichier `_Layout.cshtml`. Ce fichier est le template commun à toutes les pages/vues.  
  * Le fichier `_ViewStart.cshtml` contient des directives Razor qui sont ajoutées à toutes les vues. Dans ce fichier, la propriété `Layout` est définie avec la valeur `"_Layout"`. Le lien entre les vues et le template est donc fait ainsi.  
  * Le fichier `_ViewImports.cshtml` centralise tous les `@using` commun à toutes les vues. Ces `@using` sont l'équivalent Razor des `using` du C#, et de la même façon, permettent d'importer des namespace avec d'utiliser les classes correspondantes dans le code Razor.  

  ## Fichiers et dossiers de code c#

  ### Dossier Controllers
  A chaque  contrôleur correspond une classe C#.
  La convention de nommage impose que si le contrôleur s'appelle, `Foo`, sa classe s'appellera `FooController`.  

  Une classe de contrôleur contient des méthodes correspondant à chaque vue/action (exemple : `Index()`, `Privacy()`).  

  Dans le cas où l'action correspond simplement à renvoyer le HTML de la vue, ces méthodes renvoient simplement `return View()`.  

  ### Racine du projet
  * `Program.cs` : le point d'entrée d'exécution. En gros, le point d'entrée lance le serveur d'application web (Kestrel), qui écoute (par défaut) sur les ports HTTP 5000 et HTTPS 5001. Ce point d'entrée fait référence à la classe `Startup`.  
  * `Startup.cs` :
    * 1 constructeur qui récupère des paramètres d'on ne sait où, et les stocke dans des variables membre.  
    Ceci correspond au pattern d'**injection de dépendances** (**DI = Dependency Injection**) ou **IoC = Inversion of Concern**.  
    On y reviendra plus tard, dans les contrôleurs.  
    L'injection de dépendances est un design pattern courant, et implémenté ici en C#.  
    * 1 méthode `ConfigureServices()` : ajout dans le code des différents services et librairies utilisés. Cette méthode est appelée automatiquement lors du runtime MVC.   
    * 1 méthode `Configure()` : Configuration des options de ces mêmes services et librairies. Cette méthode est appelée automatiquement lors du runtime MVC.  
    Le routing (contruction et schéma des URLs) est défini dans cette méthode et a la forme suivante : `/controller` (valeur par défaut = home) `/vue` (valeur par défaut = index).  

## TD sur la découverte de ASP.Net MVC.

### Ajout d'un contrôleur et d'une vue
* Ajouter un contrôleur `Playground` 
* Ajouter une vue `Index` à ce contrôleur, contenant le titre `Hello World` 
  Cette vue devrait être accessible via l'url https://localhost:5001/playground/index 
* Dans `_Layout`, identifier le menu et ajouter un lien vers cette nouvelle page.  

### Logging
Utiliser l'interface `ILogger<PlaygroundController>` afin de logguer les appels à la vue index.  

Dans le fichier `appsettings.Development.json`, définir le niveau de Log de tout ce qui vient de Microsoft.* à Warning, et ce afin d'éviter que nos logs soient noyés dans le flux de ces autres logs.

Les settings sont pris dans `appsettings.json`.  
Si on est en mode `Development`, et que `appsettings.Development.json`, alors toute clé existante dans ce fichier va overrider le setting normal.  

### Refresh des contenus cshtml sans recompilation
Ajouter un package `NuGet` au projet (nom du package = `Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation`) avec la commande :
`dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation`  
Cette commande ajoute la référence au package dans le fichier .csproj, le télécharge depuis nuget.org et l'ajoute au dossier des package (dans le profil utilisateur de la machine). A exécuter depuis la racine du projet web.  

Activer cette librairie dans `Startup` > `ConfigureServices` :
````csharp
services
  .AddControllersWithViews()
  .AddRazorRuntimeCompilation();
```` 

### Différentes façon de passer des données à une vue
* Déclaration d'une variable locale dans le cshtml. Voir `/Playground/index`  
* En C# : utilisation du ViewData dans le contrôleur. ViewData est un `Dictionnary<string, object>`. Ses clés sont des chaînes de caractère, et ses valeurs sont faiblement typées (object). Donc quand on les récupère, il peut être nécessaire de les caster afin de récupérer leur type.  
* En C# : utilisation de ViewBag. ViewBag est un type `dynamic` c'est à dire que l'on peut créer des propriétés et affecter des valeurs à la volée.  
* En C# : passage d'un objet à la vue :
  * Définir une classe simple (MyDataClass)
  * L'instancier dans la méthode d'action du contrôleur
  * Passer son instance à la vue
  * Récupérer son instance dans la vue

# Création d'un véritable modèle

## Création d'une classe `Person`
Dans le projet `Isen.Dotnet.Library`, ajouter un fichier `Model/Person.cs`.
A cette classe, ajouter les champs `FirstName`, `LastName`, `DateOfBirth`, `BirthCity`, `ResidenceCity`, et un getter `Age`. Tous les types sont string, sauf la date de naissance. 
Prévoir aussi un champ `Id`, de type int.
Surcharger `ToString()` pour avoir une affichage console simple.

## Création d'un service de données
Le but est d'avoir une classe qui aura le rôle de générer des données aléatoires, et ce afin de disposer d'un jeu de données suffisant pour tester l'application dans des conditions réelles.

Toujours dans le projet Library, créer dans un dossier `Services`, une classe `DataInitializer`.   

Tester cette classe dans le projet console.  

## Création de la stack (M)VC pour Person

### Maquette du tableau de la vue Index
* Créer un `PersonController`
* Créer une vue `Index` de test.
* Créer un menu hiérachique (dropdown) avec les entrées 
  * Personnes... (non cliquable)
    * Toutes (vue index)
    * Nouvelle... (vue detail, qui n'existe pas encore)
* Dans la vue Index, prévoir un tableau qui affichera toutes les personnes.

Pour le menu hiérarchique, nous utilisons le framework CSS `Bootstrap`. Voir https://getbootstrap.com/docs/4.1/getting-started/introduction/ pour le détail des classes, attributs, etc...

### Injection du modèle (Person) dans sa vue Index
* Instancier une liste aléatoire de personnes
* Passer cette liste à la vue
* Modifier la vue afin qu'elle boucle sur la liste et affiche les champs dans le tableau

### Illustrer l'utilisation de la librairie d'injection de dépendances.

* Extraire une interface `IDataInitializer` de la classe `DataInitializer`. Ne mettre que la méthode publique.
* Dans le contrôleur, faire un membre de cette interface, l'instancier dans l'action, et l'utiliser.
* Instancier `DataInitializer` depuis le constructeur du contrôleur.
* Afin de respecter le design-pattern de l'inversion de contrôle (**`IoC`**), propre aux mécanismes d'injection de dépendance (**`DI`**), le constructeur ne doit pas instancier lui-même le service, mais au contraire, indiquer qu'il a besoin de ce service pour fonctionner. Le service `IDataInitializer` doit donc devenir un paramètre du constructeur.
* Les mappings entre interfaces et classes, utilisées par la librairie d'injection de dépendances, se configurent dans `Startup`, dans `ConfigureServices()`, avec la ligne :

````csharp
// Quand on demande un IDataInitializer, fournir 
// une instance de DataInitializer
services.AddScoped<IDataInitializer, DataInitializer>();

// AddScoped : conserver la même instance pendant toute
// la requête HTTP
services.AddScoped<IDataInitializer, DataInitializer>();
// Nouvelle instance à chaque demande
services.AddTransient<IDataInitializer, DataInitializer>();
// Même instance pendant tout le lifecycle de l'application
services.AddSingleton<IDataInitializer, DataInitializer>();
````
* De la même, injecter via le constructeur un `ILogger`.  

# Ajout d'une base de données
Le but est d'avoir un système de persistence des données, afin de stocker, pour l'instant, les personnes générées, et pouvoir les modifier au travers du formulaire d'édition que nous allons créer.

Le 'serveur' de base de données que nous allons utiliser est `SQLite`, et c'est une base de données relationnelle.  
SQLite n'est pas vraiment un serveur, mais juste un fichier, avec des librairies driver pour l'utiliser. Donc simple à mettre en oeuvre. Mais performances moyennes, et mono-user.

Tout ce que nous allons voir avec SQLite, et l'ORM Entity Framework, reste identique pour SQL Server, PostGre, MySQL, etc...

## Ajout des packages requis.
Entity Framework Core 3.0.1 nécessite que le projet auquel on l'ajoute soit `netstandard2.1`. Editer le `.csproj` du projet Library, et faire la modif.

Depuis le projet Library, ajouter les packages suivants :
`dotnet add package Microsoft.EntityFrameworkCore.Sqlite`  
`dotnet add package Microsoft.EntityFrameworkCore.Design` 

Revenir au projet web et tester si en l'état tout marche.

## Chaine de connexion
Ajouter au fichier `appsettings.json` la chaîne de connexion suivante, au format JSON :
````json
"ConnectionStrings": {
  "DefaultConnection": "DataSource=.\\IsenWeb.db"
}
````
## Ajout d'une classe de contexte 
Le fonctionnement d'Entity Framework est lié à la présence d'une classe de contexte de base données, donc le rôle :
* Définir les objets présents dans le contexte,
* Définir leurs liens avec la base de données
* Préciser, si nécessaire, les relations entre les objets (beaucoup sont implicites par convention).  

Dans le projet Library, créer un dossier Context, et une classe `ApplicationDbContext`.  

Faire hériter cette classe de `DbContext` (`using Microsoft.EntityFrameworkCore`).  

Ajouter en champ de cette classe une propriété de type `DbSet<Person>`. C'est au travers de cette propriété qu'on pourra accéder aux records de type Person dans la base de données.

Générer le constructeur de cette classe, basé sur la surcharge avec options.  

Implémenter l'override de `OnModelCreating(ModelBuilder)` et définir les tables et relations.  

Dans la classe `Person`, le champ `Age` ne doit pas donner lieu à la création d'un champ correspondant dans la base de données. Pour indiquer cela, ajouter un attribut `[NotMapped]` au dessus du champ `Age`.  

Dans `Startup` / `ConfigureService()`, ajouter le service lié à ce contexte.  

## Création d'un jeu de données au démarrage
On va utiliser `IDataInitializer` pour réaliser les opérations suivantes au démarrage de l'application :
* Supprimer (si nécessaire) puis recréer la base de données.  
* Remplir la table `Person` avec des personnes aléatoires.

Ajouter les méthodes `DropDatabase()`, `CreateDatabase()` et `AddPersons()` à l'interface, et les implémenter dans la classe.  
Pour accéder à la base de données depuis la classe `DataInitializer`, utiliser le pattern d'injections de dépendances pour disposer d'une instance de `ApplicationDbContext` dans cette classe.  

Dans (Web) Program.cs, résoudre une instance de `IDataInitializer`, et appeler successivement ces 3 méthodes.  

## Utiliser les données issues de la base de données dans le contrôleur

Via le pattern d'injection de dépendance, fournir à `PersonController` une instance de `ApplicationDbContext`.  

Remplacer alors le code de l'action Index afin qu'elle prenne ses données dans l'instance du contexte.  

Retirer l'injection de DataInitializer, qui est devenue obsolète.  

### Désactiver la reconstruction de la base.
Dans `Program.cs`, commenter les appels à Drop et Create.

### Formulaire d'édition

#### Création du canvas d'édition (principe de fonctionnement)
La liste des personnes a pour URL `/Person`, soit implicitement `/Person/Index`.  
Dans `Startup.cs`, le schéma des routes est défini ainsi : 
`{controller=Home}/{action=Index}/{id?}`

Le formulaire d'édition aura pour URL `/Person/Edit/45`.  

* Créer l'action du contrôleur permettant de passer à la vue les données d'UNE
personne,
* Créer l'action Edit dans le dossier des vues Person (dupliquer la vue Index)
* Dans l'action Index, modifier le lien généré sur le bouton "Modifier" afin de 
naviguer vers le form d'édition.
* Dans le menu, modifier l'entrée correspondant à "Personne" > "Nouvelle" afin que
ça ouvre le même formulaire, mais sans id en param.

#### Créer tous les contrôles d'édition
Utiliser les principes de mise en forme issus de la librairie bootstrap pour
réaliser le formulaire d'édition complet d'une personne.

#### Répondre à la soumission du formulaire
* Dans le contrôleur, créer une surcharge de Edit, qui prend le contenu de formulaire
posté, en POST.
* Implémenter la sauvegarde :
  * Mise à jour si Id > 0
  * Création si Id = 0

#### Supprimer une personne
* Dans la liste de `Index.cshtml`, ajouter au bouton de suppression l'envoi vers
l'action `Delete`, et le passage de l'id de la personne à supprimer en param.
* Dans le contrôleur, implémenter l'action `Delete(id)`. 

## Généralisation du contrôleur

### Hiérarchie des types de contrôleurs
* Dans le contrôleur, remplacer les références à `_context.PersonCollection` 
par `_context.Set<Person>()` et retester le fonctionnement (CRUD).  
* Renommer les variables trop spécifiques...
* Dans le dossier des contrôleurs, créer une classe abstraite `BaseController<T>`
et faire dériver `PersonController` de `BaseController<Person>`.  
`BaseController<T>` dérive quant à lui de `Controller` car `PersonController` dérivait
de `Controller`.  


La hiéarchie des types passe de :
````csharp
PersonController : Controller
```` 
à 
````csharp
PersonController : BaseController<Person> : Controller
```` 

* Déplacer `_context` et `_logger` vers `BaseController`. Ceci oblige à :
  * Créer un constructeur dans `BaseController`, et le rappeler depuis `PersonController`,
  * Changer la protection de ces 2 membres de `private` à `protected`.
* Déplacver la méthode Index()

### Généralisation des modèles (ou entités)
A partir de ce stade, le type générique `T` n'est plus suffisamment précisé
car on va avoir besoin d'accéder à son champ Id (exemple : Person.Id).

Dans Library/Model, créer une classe `BaseEntity` constituée uniquement du champ
`Id`, et faire dériver `Person` de ce nouveau type.  

Dans `BaseController`, faire évoluer la contrainte sur `T` en précisant que maintenant, 
`where T : BaseEntity`.

Rétablir le drop/create de la base de données afin de tout retester.

### Généraliser les autres méthodes du contrôleur
* Déplacer le `Edit(id)` de `PersonController` vers `BaseController`.  
* Déplacer le `Edit(Person entity)`
* Déplacer le `Delete(id)`

## Ajout d'un nouveau model : City
Nous allons répercuter cette nouvelle classe de modèle dans toutes les couches successives de l'architecture de l'app.  

### Couches en C#
* Dans Library/Model, ajouter une classe `City` avec les champs `Name`, `Zip`, `Lat` et `Lon`.  
* Dans `ApplicationDbContext`, déclarer le `DbSet<>` correspondant, et préciser la création de la table correspondant à ce modèle.  
* Dans `DataInitializer`, prévoir une liste de villes, avec leurs coordonnées :
  * `GetCities`, qui génère une liste statique de villes,
  * `AddCities()`, qui ajoute dans la base de données ces villes, si elles ne sont pas déjà présentes.
  * Ajouter la méthode `AddCities()` à l'interface `IDataInitializer`
* Dans le projet Web, `Program.cs`, appeler `AddCities()`
* Toujours dans le projet web, Créer `CityController` sur le modèle de `PersonController`.  

### Vues en CSHTML
* Dans `_Layout.cshtml`, modifier le menu en dupliquant la section Personnes et en l'adaptant pour les Villes.
* Dans le dossier des `Views`, créer le dossier `City`, puis dupliquer `Person/Index.cshtml` à l'intérieur, et adapter. 
* Dupliquer aussi `Edit.cshtml` et adapter le formulaire en conséquence.

# Ajout de relations

## Factoriser les requêtes de liste et de détails
Dans la classe `BaseController`, créer une méthode `BaseQuery` protected et virtual,permettant d'isoler la génération de la liste des entités.  

Utiliser cette méthode dans `Index`, et `Edit(id)`.  

## Ajout d'une relation dans Person, pour la ville de naissance

Nous allons créer une relation 1..n entre Person et City, au travers de la ville de naissance.

* Dans le modèle `Person.cs`, changer le type de `BirthCity`, afin que ce soit un type `City`, et ajouter un champ `BirthCityId`, qui va correspondre à la clé étrangère de cette relation.
* Dans `ApplicationDbContext`, préciser la relation au travers de la clé étrangère.
* Adapter `DataInitiliazer` :
  * Adapter RandomCity : prendre une ville aléatoirement dans la liste des villes générées en base de données
  * Adapter RandomPerson : utiliser RandomCity ou RandomCity.Name, selon le cas.
* Adapter Views/Person/Index car le tableau utilise encore la ville au format string.
* Adapter `PersonController`, en incluant City dans la relation Person lors des requêtes.

## Même chose pour la ville de résidence

Répéter les mêmes étapes d'adaptation pour la ville de résidence.
* Dans la classe Person
* Dans ApplicationDbContext
* Dans DataInitializer
* Include dans PersonController
* Tableau dans Index.cshtml

## Formulaire d'édition du personne.

Remplacer la zone de texte correspondant à la ville, par une liste déroulante.

# Création d'une API

## Méthode générique de renvoi des données en JSON
Nous allons créer des méthodes de controller permettant de lister les différentes entités au format JSON.  

Dans `BaseController`, créer une méthode `GetData()`, qui renvoie la liste des entités du controller.

Lors de l'appel des url ainsi exposées (https://localhost:5001/api/Person ou https://localhost:5001/api/City), les données sont renvoyées en JSON.

## Exploitation de ces données en JavaScript via AJAX
* Créer une vue/action correspondant à `/Home/Ajax`. Tester cette vue avec https://localhost:5001/Home/Ajax
* Ajouter cette vue au menu
* Dans cette vue, ajouter un bloc div avec l'id result.
* Ouvrir le fichier `/wwwroot/js/site.js` et coder un appel Ajax à l'API /api/city, et afficher le résultat sous forme d'une liste.