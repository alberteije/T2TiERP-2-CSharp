using System.Collections.Generic; 
using System.Text; 
using System; 


namespace EstoqueService.Model {
    
    public class EstoqueDTO {
        public EstoqueDTO() { }
        public int? id { get; set; }
        public ProdutoDTO produto { get; set; }
        public string quantidade { get; set; }
    }
}
