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

  ## Créer un remote
* Sur Github / GitLab (ou autre), créer un repo remote pour ce projet.  
* Ajouter ce remote comme upstream du repo local :
`git remote add origin https://github.com/kall2sollies/Isen2019-11`  
* commit initial du projet :
  `git add .`  
  `git commit -m "initial commit"`  
  `git push origin master`  