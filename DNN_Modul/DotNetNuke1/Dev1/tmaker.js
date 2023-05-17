const THREE = window.THREE;
const STLLoader = THREE.STLLoader;

// Create a scene
let scene = new THREE.Scene();

// Create a camera
let camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
camera.position.z = 5;

// Create a renderer
let renderer = new THREE.WebGLRenderer({ alpha: true });

renderer.setSize(window.innerWidth, window.innerHeight);
document.getElementById('tmaker-3D-model-div').appendChild(renderer.domElement);

// Create an STLLoader
let loader = new STLLoader();

// Load the STL file
loader.load('Tshirt.stl', function (geometry) {
    // Create a material
    let material = new THREE.MeshNormalMaterial();

    // Create a mesh with the geometry and material
    let mesh = new THREE.Mesh(geometry, material);

    // Add the mesh to the scene
    scene.add(mesh);

    // Create a render loop
    function animate() {
        requestAnimationFrame(animate);
        mesh.rotation.x += 0.01;
        mesh.rotation.y += 0.01;
        renderer.render(scene, camera);
    }

    animate();
});
