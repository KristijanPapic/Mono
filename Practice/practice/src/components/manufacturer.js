import '../App.css';
import {Container,Row} from 'reactstrap';
import { Link } from 'react-router-dom'

function Manufacturer({manufacturer}){
    return (
        <Container className="bg-light border">
            <Row><img className="man_img" src={manufacturer.ImageURL} alt="" /></Row>
            <Link to={'/Manufacturer/' + manufacturer.Id}><Row><p>{manufacturer.Name}</p></Row></Link>
        </Container>
    );
}

export default Manufacturer