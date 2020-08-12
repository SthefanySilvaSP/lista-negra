import React from 'react';
import './App.css';
import { Link } from 'react-router-dom';

export default function App() {
    return (
        <div className="box">
            <div className="titulo">
                <h1>Bem vindo à Lista Negra Online</h1>
                <h1>O que deseja fazer?</h1>
            </div>
            <div className="opcoes">
                <h2> <Link to="/cadastrar"> Cadastrar </Link> </h2>
                <h2> <Link to="/consultar"> Consultar </Link> </h2>
            </div>
        </div>
    );
}