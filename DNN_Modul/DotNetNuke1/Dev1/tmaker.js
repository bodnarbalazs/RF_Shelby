const THREE = window.THREE;
const OBJLoader = THREE.OBJLoader;
const MTLLoader = THREE.MTLLoader;

let scene = new THREE.Scene();
let camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
camera.position.z = 5;
camera.position.y = -4;

let isImageUploaded = false;
let renderer = new THREE.WebGLRenderer({ alpha: true });
renderer.setSize(window.innerWidth, window.innerHeight);
document.getElementById('tmaker-3D-model-div').appendChild(renderer.domElement);
let light = new THREE.DirectionalLight(0xffffff, 0.4);
light.position.set(0, 1, 1);
scene.add(light);
let ambientLight = new THREE.AmbientLight(0xffffff, 0.7);
scene.add(ambientLight);

let mtlLoader = new MTLLoader();
let currentModel;
let models = {};

function loadModel(name, mtlPath, objPath, scale) {
    mtlLoader.load(mtlPath, function (materials) {
        materials.preload();

        let objLoader = new OBJLoader();
        objLoader.setMaterials(materials);
        objLoader.load(objPath, function (object) {
            object.scale.set(scale, scale, scale);
            object.position.set(0, -4, -4);

            let tshirtFrontMaterial, baseMaterial;

            object.traverse((node) => {
                if (node.isMesh) {
                    if (node.material.name === 'TshirtFront') {
                        tshirtFrontMaterial = node.material;
                    } else if (node.material.name === 'Base') {
                        baseMaterial = node.material;
                    }
                }
            });

            models[name] = {
                object: object,
                materials: {
                    TshirtFront: tshirtFrontMaterial,
                    Base: baseMaterial
                }
            };

            if (!currentModel) switchModel(name);
            //changeColorAllModels(0x12b0b0); //bit színek
            changeColorAllModels(0x888888);
        });
    });
}

loadModel('male', 'maleShirt8.mtl', 'maleShirt8.obj', 0.13);
loadModel('female', 'femaleShirt2.mtl', 'femaleShirt2.obj', 0.15);

let shouldRotate = true;

let controls = new THREE.OrbitControls(camera, renderer.domElement);
controls.enablePan = false;  // disable panning
controls.enableZoom = false; // disable zooming
controls.enableDamping = true;
controls.dampingFactor = 0.1;
controls.autoRotate = false; // disable automatic rotation
controls.minPolarAngle = Math.PI / 3; // radians
controls.maxPolarAngle = Math.PI / 2; // radians
controls.target = new THREE.Vector3(0, -1, -4);

function animate() {
    requestAnimationFrame(animate);
    if (currentModel && shouldRotate && currentModel.object.rotation) {
        currentModel.object.rotation.y += 0.01;
    }
    controls.update();
    renderer.render(scene, camera);
}
let rotationTimeout;

renderer.domElement.addEventListener('mousedown', function () {
    shouldRotate = false;
    if (rotationTimeout) {
        clearTimeout(rotationTimeout);
    }
});

renderer.domElement.addEventListener('mouseup', function () {
    rotationTimeout = setTimeout(function () {
        shouldRotate = true;
    }, 10000); // Delay for 10 seconds
});


animate();

function switchModel(modelName) {
    if (currentModel) {
        scene.remove(currentModel.object);
    }
    currentModel = models[modelName];
    scene.add(currentModel.object);
}

function switchGender() {
    var maleButton = document.getElementById('maleSize');
    var femaleButton = document.getElementById('femaleSize');
    var switcher = document.querySelector('#gender-switcher-div .switcher');

    if (maleButton.classList.contains('selected')) {
        maleButton.classList.remove('selected');
        femaleButton.classList.add('selected');
        switcher.style.left = '52.5px';
        switchModel('female');
    } else {
        maleButton.classList.add('selected');
        femaleButton.classList.remove('selected');
        switcher.style.left = '2.5px';
        switchModel('male');
    }
}

function deleteImageAllModels() {
    isImageUploaded = false;
    for (let modelName in models) {
        let model = models[modelName];
        if (model && model.materials.TshirtFront) {
            model.materials.TshirtFront.map = null;
            model.materials.TshirtFront.color.set(model.materials.Base.color);
            model.materials.TshirtFront.needsUpdate = true;
        }
    }
}

function changeColorAllModels(colorHex) {
    for (let modelName in models) {
        let model = models[modelName];
        if (model.materials.Base) {
            model.materials.Base.color.setHex(colorHex);
            model.materials.Base.needsUpdate = true;
        }
        if (!isImageUploaded && model.materials.TshirtFront) {
            model.materials.TshirtFront.color.setHex(colorHex);
            model.materials.TshirtFront.needsUpdate = true;
        }
    }
}

window.tColour = function (colour) {
    let colorHex;
    if (colour === 'custom') {
        document.getElementById('colorPicker').click();
    } else {
        switch (colour) {
            case 'red':
                colorHex = 0xff0000;
                break;
            case 'white':
                colorHex = 0xffffff;
                break;
            case 'green':
                colorHex = 0x008000;
                break;
            case 'blue':
                colorHex = 0x0000ff;
                break;
            case 'yellow':
                colorHex = 0xffff00;
                break;
            default:
                colorHex = 0x7777ff;  // default color
        }
        changeColorAllModels(colorHex);
    }
};

window.tColourCustom = function () {
    let colorPicker = document.getElementById('colorPicker');
    let colorHex = colorPicker.value;
    colorHex = parseInt(colorHex.replace(/^#/, ''), 16);
    changeColorAllModels(colorHex);
};

window.uploadClicked = function (event) {
    isImageUploaded = true;
    for (let modelName in models) {
        let model = models[modelName];
        if (model.materials.TshirtFront) {
            model.materials.TshirtFront.color.setHex(0xffffff);  // set color to white
            model.materials.TshirtFront.needsUpdate = true;
        }
    }

    let reader = new FileReader();
    reader.onload = function (event) {
        let img = new Image();
        img.onload = function () {
            let texture = new THREE.TextureLoader().load(img.src);
            texture.wrapS = THREE.RepeatWrapping;
            texture.wrapT = THREE.RepeatWrapping;
            for (let modelName in models) {
                let model = models[modelName];
                if (model.materials.TshirtFront) {
                    model.materials.TshirtFront.map = texture;
                    model.materials.TshirtFront.needsUpdate = true;
                }
            }
        };
        img.src = event.target.result;
    };
    reader.readAsDataURL(event.target.files[0]);
};

window.deleteImage = function () {
    deleteImageAllModels();
};
