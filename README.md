# DemoValidations

## Validation Client

On peut voir qu'en accédant à la page de création de MonModel et en entrant des données invalides, on voit tout de suite les messages d'erreurs sur le client.

Si on ajoute un point d'arrêt à la méthode Edit (httpPost), aucun appel n'est fait. C'est que la validation a été faite par un script JS sur le client.

## Validation Serveur

En retirant les 3 dernières ligne du fichier Create.cshtml à propos du script de validation partiel, on peut refaire la même chose et cette fois la méthode serveur est appelé.

Si les données ne sont pas valides, ModelState.IsValid est false et on retourne donc à la même page et on peut voir les erreurs qui s'affichent toujours.

## Validation BD

En mettant en commentaire la ligne if(ModelState.IsValid), on peut refaire la même chose et cette fois une opération de BD est effectué avec des données invalides (Commencer par un test avec le champ Requis vide!).

Il est intéressant de réaliser que la BD ne valide pas toutes les annotations de validation.
Elle va:
  - Permettre des valeurs plus petite que 3 ou plus grande que 10 pour le champ Valeur
  - Permettre un chaîne de caractères plus petites que 5 pour le champ optionnel

C'est donc très important de toujours vérifier si ModelState.IsValid est vrai avant de faire notre opération dans la BD!
