import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { HttpService } from '../http.service';
import { ProductspageComponent} from '../productspage/productspage.component';

@Component({
  selector: 'app-editproduct',
  templateUrl: './editproduct.component.html',
  styleUrls: ['./editproduct.component.css']
})
export class EditproductComponent implements OnInit {
  editInfo: any;
  @Input() editid;
  errors: any;
  constructor(private _router: Router, private _route: ActivatedRoute, private _httpService: HttpService) { }

  ngOnInit() {
    this.editInfo = {name: "", price: null, image: ""};
    console.log("inside oninit in editproduct component");
  }
  editProduct() {
    this._route.params.subscribe(data => {
      let id = data.id;
      let observe = this._httpService.editProduct(id, this.editInfo);
      observe.subscribe(data2 => {
        console.log(data2);
        this.errors = data2.errors;//ignore this, its just vs code.
        this.editInfo = {name: "", price: null, image: ""};
        if(!this.errors) {
          this._router.navigateByUrl('/products');
          this._httpService.getAllProducts().subscribe(data => {
            console.log(data);
          })
        }
      })
    })
  }
  deleteProduct() {
    this._route.params.subscribe(data => {
      let observe = this._httpService.deleteProduct(data.id);
      observe.subscribe(data => {
        console.log(data);
        this._router.navigate(['/products']);
        this._httpService.getAllProducts().subscribe(data => {
          console.log(data);
        })
      })
    })
  }
}
