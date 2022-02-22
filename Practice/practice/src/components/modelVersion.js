import {useParams} from 'react-router-dom'
import{useState,useEffect} from 'react'
import axios from 'axios';
import{Container,Row,Col} from 'reactstrap'
import Model from './model.js'
import '../App.css'


function ModelVersion(modelVersion){
    return(
        <Container className='bg-light border my-2' id='list_con'>
            <Row>
                <Col>
                <img className='mod_img' src={modelVersion.modelVersion.Model.ImageURL}/>
                </Col>
                <Col>
                <p>{modelVersion.modelVersion.Model.Manufacturer.Name} {modelVersion.modelVersion.Model.Name} {modelVersion.modelVersion.Name}</p>
                </Col>
            </Row>
        </Container>
    )
}

export default ModelVersion