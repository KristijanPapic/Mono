import '../App.css';
import {Container,Row} from 'reactstrap';
import { Link } from 'react-router-dom'

function Manufacturer({manufacturer}){
    return (
        <Container id='man_con' className="bg-light border m-1">
            <Row><img className='man_img' src={manufacturer.ImageURL} alt="" /></Row>
            <Row className='man_name'><Link to={'/Manufacturer/' + manufacturer.Id}><p>{manufacturer.Name}</p></Link></Row>
        </Container>
    );
}

export default Manufacturer