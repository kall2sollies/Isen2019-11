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