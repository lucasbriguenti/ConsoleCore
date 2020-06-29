import { Component, OnInit } from '@angular/core';
import { EventoService } from '../_services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventosFiltrados: any = [];
  _eventos: any = [];
  get eventos(): any{
    return this._eventos;
  }
  set eventos(result: any){
    this._eventos = result;
    this.filtroLista = "";
  }


  imagemLargura = 50;
  imagemMargin = 2;
  mostrarImagem = false;
  _filtroLista: string;
  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }
  
  constructor(private eventoService: EventoService) { }

  ngOnInit() {
    this.getEventos();
  }

  filtrarEventos(filtro: string): any{
    filtro = filtro.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtro) !== -1
    );
  }
  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }

  getEventos(){
    this.eventoService.getEvento().subscribe(
      response => {this.eventos = response;},
      error => {console.log(error);}
    );
  }
}
