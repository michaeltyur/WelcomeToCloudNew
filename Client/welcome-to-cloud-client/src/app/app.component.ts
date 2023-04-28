import { Component } from '@angular/core';
import { ConnectionService } from './shared/services/connection.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'welcome-to-cloud-client';
  url = "";
  constructor(private connectionService: ConnectionService){
    connectionService.$urlEmitter.subscribe(x=>{
      this.url = x;
    })
  }

  checkedChange(event: any): void {
    this.connectionService.$frameworkChangedEmitter.emit(event);
  }
}
