import { useState } from 'react';
import {Container,Row,Col} from 'reactstrap';
import Manufacturer from './manufacturer';



function Manufacturers({manufacturers}){
    return(
        <Container>
            <Row>
                {manufacturers.map((manufacturer) => (
                    <Col key={manufacturer.Id}>
                    <Manufacturer manufacturer={manufacturer}/>
                    </Col>
                ))}
                    
            </Row>
           
        </Container>
        
    );
}

export default Manufacturers