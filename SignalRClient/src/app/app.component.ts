import { Component, OnInit } from "@angular/core";
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';


@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent implements OnInit {
  public _hubConnecton: HubConnection;

  hubPath = "https://localhost:5001/message";
  messages: string[] = [];

  ngOnInit(): void {
    this._hubConnecton = new HubConnectionBuilder().withUrl(this.hubPath).build();

     this._hubConnecton
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

    this._hubConnecton.on('send', (type: string, payload: string) => {
     this.messages.push(type);
    });


  }
}