import React from 'react';
import './App.css';
import { Link } from 'react-router-dom';

export default function App() {
    return (
        <div className="main_box">
            <div className="titulo">
                <h1>Bem vindo(a) à Lista Negra Online!</h1>
                <h1>O que deseja fazer?</h1>
            </div>
            <div className="opcoes">
                <h2> <Link to="/cadastrar" className="btn"> Cadastrar </Link> </h2>
                <h2> <Link to="/consultar" className="btn"> Consultar </Link> </h2>
            </div>
        </div>
    );
}