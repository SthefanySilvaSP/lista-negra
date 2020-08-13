import React, { useState, useRef } from 'react';
import LoadingBar from 'react-top-loading-bar';
import './Consultar.css';

import ListaNegraApi from '../../services/ListaNegraAPI'
import ListaNegraAPI from '../../services/ListaNegraAPI';
const api = new ListaNegraAPI();


export default function Consultar() {

    const loadingBar = useRef(null);

    const [registros, setRegistros] = useState([])

    const consultarClick = async () => {
        loadingBar.current.continuousStart();

        const lns = await api.consultar()
        setRegistros([...lns])

        loadingBar.current.complete();

        document.getElementById("table_box").style.display = "block";
    }

    return (
        <div className="content">
            
            <LoadingBar
                height={4}
                color='#f11946'
                ref={loadingBar}
                />
        
            <h1>Consulte a Lista Negra</h1>

            <button onClick={consultarClick} className="btn_consultar">Consultar</button>

            <div id="table_box">
                <table className="table">
                    <thead className="thead-dark">
                        <tr>
                            <th>ID</th>
                            <th>Nome</th>
                            <th>Motivo</th>
                            <th>Inclusão</th>
                        </tr>
                    </thead>

                    <tbody>
                        {registros.map(item => 
                            <tr key={item.id}>
                                <th>#{item.id}</th>
                                <td>{item.nome}</td>
                                <td>{item.motivo}</td>
                                <td> { new Date(item.dataInclusao + 'Z').toLocaleString() }</td>
                            </tr>    
                        )}
                    </tbody>
                </table>
            </div>
        </div>
    );
}