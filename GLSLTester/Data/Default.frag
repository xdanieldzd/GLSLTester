#version 330 compatibility

in vec4 fragmentColor;
in vec2 fragmentTextureCoord;

out vec4 color;

varying vec4 diffuse, ambient;
varying vec3 normal, halfVector;

uniform sampler2D textureMap0;
uniform int passNumber;

void main(void)
{
    vec4 textureColor = texture(textureMap0, fragmentTextureCoord);

    vec4 lightColor = ambient;
    vec3 n = normalize(normal);
    vec3 lightDir = vec3(gl_LightSource[0].position.xyz);

    float NdotL = max(dot(n, lightDir), 0.0);
    if (NdotL > 0.0)
    {
        lightColor += diffuse * NdotL;

        vec3 halfV = normalize(halfVector);
        float NdotHV = max(dot(n, halfV), 0.0);

        lightColor += gl_FrontMaterial.specular * gl_LightSource[0].specular * pow(NdotHV, gl_FrontMaterial.shininess);
    }

    color = lightColor * (fragmentColor * textureColor);
}
