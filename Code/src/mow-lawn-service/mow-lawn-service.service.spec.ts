import { Test, TestingModule } from '@nestjs/testing';
import { MowLawnServiceService } from './mow-lawn-service.service';

describe('MowLawnServiceService', () => {
  let service: MowLawnServiceService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [MowLawnServiceService],
    }).compile();

    service = module.get<MowLawnServiceService>(MowLawnServiceService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });
});
