#version 150

in vec4 fragmentColor;
in vec2 fragmentTextureCoord;

out vec4 color;

in vec4 diffuse, ambient;
in vec3 normal, halfVector;

uniform sampler2D textureMap0;
uniform int passNumber;

void main(void)
{
	vec4 textureColor = texture(textureMap0, fragmentTextureCoord);

	if (passNumber == 0)
	{
		color.rgb = (fragmentColor.rgb * textureColor.rgb) * 0.25;
		color.a = 1.0;
	}
	else if (passNumber == 1)
	{
		vec3 n = normalize(normal);
		vec3 lightDir = vec3(gl_LightSource[0].position.xyz);

		float NdotL = max(dot(n, lightDir), 0.0);
		vec4 toonColor = vec4(1.0, 1.0, 1.0, 1.0);
		if (NdotL < 0.5) toonColor.xyz = vec3(0.75, 0.75, 0.75);

		color = toonColor * (fragmentColor * textureColor);
	}
}
