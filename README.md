# Projet Isen VR

Futur projet de Réalité Virtuelle de Troisième année à l'ISEN

## Comment initaliser le projet ?

### Installer Unity

Il suffit de récupérer l'exécutable de Unity, et de l'installer sur votre Windows ou votre Mac.
Voici le lien du site : 
> https://store.unity.com/download?ref=personal

Bien vérifier que la version est la 5.6 ou supérieure !

### Lancer le projet

Créer un nouveau projet Unity, dans le dossier où vous souhaitez qu'il soit contenu.

### Initialiser le git

A l'aide d'un terminal, aller dans le dossier du projet, et taper les lignes suivantes.

```
git clone https://github.com/Adrylen/ProjetIsenVR.git
```

Vous aurez alors accès au projet en l'état.

### Coder, c'est la vie

Explicite, à vos claviers !

## Utilisation de Jenkins

Nous possédons pour ce projet un dépôt Jenkins, mit en ligne à l'adresse suivante (encore temporaire)

> http://jenkins.luneau.me

### Comment cela fonctionne ?

Quand vous êtes connecté, vous avez accès au dépôt du projet contenant lui le dépôt git. Le dépôt git est directement relié au GitHub que nous utilisons, et chaque push enclenchera un build complet du projet git.

ATTENTION : Sachez que seuls les scripts C# placés dans le dossier Assets/scripts seront pris en compte !

Si votre build suivant votre push s'est bien passé, la branche où vous avez push s'ornera d'une pastille bleue.
Si votre build s'est mal passé, alors la pastille deviendra rouge.

L'indicateur météo référence les 5 derniers builds, et informe si ceux-là se sont bien passés en moyenne : 

* Soleil : 5/5 derniers builds passés
* Eclaircie : 4/5 derniers builds passés
* Nuageux : 3/5 derniers builds passés
* Pluvieux : 2/5 derniers builds passés
* Orageux : 0-1/5 derniers builds passés

Pour consulter les logs d'un build, cliqué sur son identifiant dans la branche, et allez dans "Console Logs".

Bonne utilisation !

## Intégrations

### Intégration de GitHub à Trello

Permission d'accès aux commits via Trello pour assignation du travail effectué

### Intégration de GitHub à Slack

La liste des comits effectués lors d'un push sera affichée dans le channel #gitactivity

### Intégration de Jenkins à Slack

Lors d'un push, un build est exécuté et l'information parvient au Slack sur le channel #jenkinsbuilds

* Si le commit s'est bien passé, il apparait vert
* Sinon, le message apparait rouge
* Si l'information n'apparait pas rapidement, le problème vient d'ailleurs. Dans ce cas, ne pas hésiter à contacter les admins du Jenkins

## Tuto Téléportation

Lien pour un tuto peut-être sympa : 

> https://www.youtube.com/watch?v=4Z4VW2pSXNM
 