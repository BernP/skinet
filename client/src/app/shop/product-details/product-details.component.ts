import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';
import { Breadcrumb } from 'xng-breadcrumb/lib/types/breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute, private bcService: BreadcrumbService) { 
    this.bcService.set('@productDetails', '');
  }

  ngOnInit(): void {
    this.loadProcuct();
  }
  loadProcuct()
  {
    this.shopService.getProduct(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(p =>{
      this.product = p;
      this.bcService.set('@productDetails', p.name);
    }, error => {
      console.log(error);
    } );
  }

}
