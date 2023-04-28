import { Component } from '@angular/core';
import { ResponseEntity } from 'src/app/shared/models/response-entity';
import { ConnectionService } from 'src/app/shared/services/connection.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent {
  factLoader: boolean = false;

  error:string|undefined = undefined;
  response:ResponseEntity|undefined;
  // frVersion:string|undefined;
  //cardTitle:string|undefined = "";
  // cartBody: string|undefined = "";
  // currentUser:string|undefined = "";
  // timeStamp:Date|undefined;

  constructor(private connectionService: ConnectionService) {
    connectionService.$frameworkChangedEmitter.subscribe(r=>{
      this.response = undefined;
    });
  }
  getRandomFact(): void {
    this.factLoader = true;
    this.connectionService.getRandomFact().subscribe({
      next: (r:ResponseEntity) => {
        console.log(r);
        this.error = undefined;
        this.response = r;
        // this.cardTitle = r.metaData!;
        // this.frVersion = r.frVersion;
        // this.cartBody = r.data!;
        // this.currentUser = r.currentUser!;
        // this.timeStamp = r.timeStamp;
       },
      error: (e) => { 
        console.error(e) ;
        //alert(e.message);
        this.error = e.message;
        this.factLoader = false;
       // this.cardTitle = `ERROR`;
        this.response = undefined;
        // this.frVersion = undefined;
        // this.cartBody = undefined;
        // this.currentUser = undefined;
        // this.timeStamp = undefined;
      },
      complete:()=>{
        this.factLoader = false;
      }
    })
  }

}
