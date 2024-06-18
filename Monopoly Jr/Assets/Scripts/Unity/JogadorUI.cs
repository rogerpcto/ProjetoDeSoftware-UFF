using Game;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unity
{
    public class JogadorUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _saldo;
        [SerializeField]
        private Transform _gridPropriedades;
        [SerializeField]
        private PropriedadeUI _propriedadePrefab;
        [SerializeField]
        private Image _image;
        private List<PropriedadeUI> _propriedadesUI = new();

        public void MudarVez(bool ativar)
        {
            _image.enabled = ativar;
        }

        public void AtualizarSaldo(int novoSaldo)
        {
            _saldo.text = $"$ {novoSaldo}";
        }

        public void AdicionaPropriedade(Propriedade propriedade)
        {
            PropriedadeUI propriedadeUI = Instantiate(_propriedadePrefab);
            propriedadeUI.Inicializar(propriedade);
            propriedadeUI.transform.SetParent(_gridPropriedades);
            _propriedadesUI.Add(propriedadeUI);
        }
        
        public void RemovePropriedade(Propriedade propriedade)
        {
            PropriedadeUI propriedadeUI = _propriedadesUI.Find(p => p.Nome == propriedade.GetNome());
            Destroy(propriedadeUI.gameObject);
        }

    }
}