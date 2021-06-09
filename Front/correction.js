(function () {
  // Contrairement à la correction précédente, compteurLignes n'est pas une variable globale.
  // Elle n'est disponible qu'à l'intérieur de la fonction anonyme.
  var compteurLignes;

  /**
   * Ajoute une confirmation pour le clique sur l'élément fournit en paramètre.
   * @param {HTMLElement} htmlElt
   */
  function ajouterConfirmation(htmlElt) {
    htmlElt.addEventListener('click', function (event) {
      if(!confirm('Êtes-vous sûr ?')) {
        event.preventDefault();
      }
    });
  }

  /**
   * Appelée lors du chargement de la page pour initialiser le formulaire ainsi que ses contrôles.
   */
  function initForm() {
    var form = document.querySelector('form');

    form.addEventListener('submit', onSubmit);

    document.getElementById('ajout-article').addEventListener('click', ajouterLigneProduit);
  }

  /**
   * Ajoute une ligne dans le tableau.
   */
  function ajouterLigneProduit() {
    var tbody = document.querySelector('#articles tbody');
    var ligne = document.createElement('tr');
    // Utiliser tbody.childElementCount à chaque fois ne serait pas fiable à cause du cas de suppression de ligne.
    var name = 'produit_' + (++compteurLignes) + '_';

    { // Ajout du nom.
      var nomCol = document.createElement('td');
      var nomChamp = document.createElement('input');

      nomChamp.type = 'text';
      nomChamp.required = 'required';
      nomChamp.name = name + 'nom';

      nomCol.appendChild(nomChamp);
      ligne.appendChild(nomCol);
    }

    { // Ajout du prix.
      var prixCol = document.createElement('td');
      var prixChamp = document.createElement('input');

      prixChamp.type = 'number';
      prixChamp.required = 'required';
      prixChamp.name = name + 'prix';

      prixCol.appendChild(prixChamp);
      ligne.appendChild(prixCol);
    }

    { // Ajout des actions (suppression de la ligne).
      var actionsCol = document.createElement('td');
      var delAction = document.createElement('button');

      delAction.innerText = 'Supprimer';
      delAction.classList = 'btn btn-danger';
      delAction.type = 'button';

      delAction.addEventListener('click', supprimerLigneProduit);

      actionsCol.appendChild(delAction);
      ligne.appendChild(actionsCol);
    }

    tbody.appendChild(ligne);
  }

  /**
   *
   * @param {Event} event
   */
  function supprimerLigneProduit(event) {
    /** @var {HTMLElement} btn */
    var btn = event.target;
    var tr = btn.closest('tr'); // ou btn.parent.parent

    // Libération du listener.
    btn.removeEventListener('click', supprimerLigneProduit);

    // Suppression de la ligne.
    tr.remove();
  }

  /**
   * Appelé sur envoir du formulaire.
   * @param {Event} event
   */
  function onSubmit(event) {
    event.preventDefault();

    var toutesLesValeurs = [];
    var champs = document.querySelectorAll('input:not([type="submit"]), textarea, select');

    for (var index = 0; index < champs.length; ++index) {
      var nom = champs[index].name;
      var valeur = champs[index].value;

      toutesLesValeurs.push(nom + '=' + valeur);
    }

    window.alert('Les valeurs du formulaire sont : ' + toutesLesValeurs.join(', '));
  }

  compteurLignes = document.querySelector('#articles tbody').childElementCount;

  // Initialisation du bouton reset (pas demandé dans l'exercice).
  document.querySelectorAll('.btn-danger').forEach(ajouterConfirmation);

  initForm();
})();