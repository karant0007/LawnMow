import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';
import { SwaggerModule, DocumentBuilder } from '@nestjs/swagger';

async function bootstrap() {
  const app = await NestFactory.create(AppModule);
  
  const options = new DocumentBuilder()
    .setTitle('Mow Lawn API')
    .setDescription('These APIs are used for mow lawn application')
    .setVersion('1.0')
    .addTag('mowlawn')
    .build();
  const document = SwaggerModule.createDocument(app, options);
  //This will set up swagger with the /api url. you have to setup url startup with /api
  SwaggerModule.setup('', app, document);

  await app.listen(3000);
}
bootstrap();
